using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using PetShelter.BusinessLayer;
using PetShelter.BusinessLayer.ExternalServices;
using PetShelter.BusinessLayer.Validators;
using PetShelter.DataAccessLayer;
using PetShelter.DataAccessLayer.Repository;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<PetShelterContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PetShelterConnection"),
        providerOptions =>
        {
            providerOptions.MigrationsAssembly("PetShelter.DataAccessLayer");
            providerOptions.EnableRetryOnFailure();
        }));

builder.Services.AddHttpClient();
builder.Services.AddScoped<IIdNumberValidator, IdNumberValidator>();
builder.Services.AddScoped<IPetService, PetService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IDonationRepository, DonationRepository>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPetRepository, PetRepository>();

builder.Services.AddValidatorsFromAssemblyContaining<RescuePetRequestValidator>();
builder.Services.AddFluentValidationAutoValidation(fv =>
{
    fv.DisableDataAnnotationsValidation = true;
}).AddFluentValidationClientsideAdapters();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.Converters.Add(new StringEnumConverter());
}); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen((options =>
{
    options.CustomSchemaIds(type => type.ToString());
}
));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

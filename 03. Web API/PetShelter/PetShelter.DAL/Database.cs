namespace PetShelterDemo.DAL;

public sealed class Database
{
    public static bool ConnectionIsDown = false;
    private static readonly TimeSpan Latency = TimeSpan.FromMilliseconds(500);

    private readonly Dictionary<Type, ICollection<object>> documents;

    public Database()
    {
        documents = new Dictionary<Type, ICollection<object>>();
    }

    public async Task Insert<T>(T document)
    {
        await CheckConnection();

        if (!documents.ContainsKey(typeof(T)))
        {
            documents.Add(typeof(T), new List<object>());
        }

        documents[typeof(T)].Add(document);
    }

    public async Task<IReadOnlyList<T>> GetAll<T>()
    {
        await CheckConnection();

        if (!documents.ContainsKey(typeof(T)))
        {
            return new List<T>();
        }

        return documents[typeof(T)].Select(o => (T)o).ToList();
    }

    private static async Task CheckConnection()
    {
        await Task.Delay(Latency);
        if (ConnectionIsDown) throw new Exception("Cannot connect to Database");
    }
}
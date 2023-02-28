import axios from 'axios';
import { Person } from '../models/Person';
import { Pet } from '../models/Pet';

export class PetService {

    private apiUrl: string = "https://localhost:7075";

    public getAll(): Promise<Pet[]> {
        return axios
        .get(this.apiUrl + '/Pets')
        .then(response => {
            console.log(response.data);

            var petsResponse: Pet[] = [];
            response.data.forEach((petFromApi: IdentifiablePetDto) => {

                let rescuer = new Person(petFromApi.rescuer.name, petFromApi.rescuer.idNumber);
                let adopter = petFromApi.adopter ? new Person(petFromApi.adopter.name, petFromApi.adopter.idNumber) : undefined;

                petsResponse.push(
                    new Pet(
                        petFromApi.name, 
                        petFromApi.imageUrl,
                        petFromApi.type,
                        petFromApi.description,
                        petFromApi.birthDate,
                        petFromApi.weightInKg,
                        rescuer,
                        adopter
                    )
                )
            });

            return petsResponse;
        })
    }

    rescue(pet: Pet): Promise<void> {

        let rescuedPet: RescuedPetDto = {
            name: pet.name,
            description: pet.description,
            birthDate : pet.birthdate,
            imageUrl : pet.imageUrl,
            isHealthy : true,
            rescuer : {
                dateOfBirth : new Date(),
                idNumber : pet.rescuer.id,
                name : pet.rescuer.name
            },
            type: pet.type,
            weightInKg: pet.wieghtInKg
        }

        return axios.post(this.apiUrl + '/Pets', rescuedPet);
    }
}

interface PetDto
{
    birthDate: Date;
    description: string;
    imageUrl: string;
    isHealthy: boolean;
    name: string;
    weightInKg: number;
    type: string;
}

interface PersonDto
{
    name: string; 
    dateOfBirth: Date | undefined; 
    idNumber: string; 
}

interface IdentifiablePetDto extends PetDto
{
    id: number;
    rescuer: PersonDto;
    adopter: PersonDto;
}

interface RescuedPetDto extends PetDto
{
    rescuer: PersonDto;
}

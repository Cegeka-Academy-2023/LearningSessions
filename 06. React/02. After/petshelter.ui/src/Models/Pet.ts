import { Person } from "./Person";

export enum AnimalType{
    Cat="Cat",
    Dog = "Dog"
}

export class Pet {
    id: number;
    name: string;
    imageUrl: string;
    type: AnimalType;
    description: string;
    birthdate: Date;
    isHealthy: boolean;
    weightInKg: number;
    isSheltered: boolean;
    rescuer: Person;
    adopter?: Person;

    constructor(id: number, name: string, imageUrl: string, type: AnimalType, description:string, birthdate: Date, isHealthy: boolean, weightInKg: number, isSheltered: boolean, rescuer: Person, adopter?: Person) {
        this.id = id;
        this.name = name;
        this.imageUrl=imageUrl;
        this.type = type;
        this.description = description;
        this.birthdate = birthdate;
        this.isHealthy = isHealthy;
        this.weightInKg = weightInKg;
        this.isSheltered = isSheltered;
        this.rescuer = rescuer;
        this.adopter = adopter;
    }
}
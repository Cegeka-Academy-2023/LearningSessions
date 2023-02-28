import type { Person } from "./Person";

export class Pet {
    name: string;
    imageUrl: string;
    description: string;
    birthdate: Date;
    type: string;
    rescuer: Person;
    adopter?: Person;
    wieghtInKg: number

    constructor(name: string, imageUrl: string, type: string, description:string, birthdate: Date, wieghtInKg: number, rescuer: Person, adopter?: Person) {
        this.name = name;
        this.imageUrl=imageUrl;
        this.type = type;
        this.description = description;
        this.birthdate = birthdate;
        this.rescuer = rescuer;
        this.adopter = adopter;
        this.wieghtInKg = wieghtInKg;
    }
}
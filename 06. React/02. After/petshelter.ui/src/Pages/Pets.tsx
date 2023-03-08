import { Box, Button, Container, Grid } from "@mui/material";
import { Fragment } from "react";
import { Link } from "react-router-dom";
import { PetCard } from "../Components/PetCard";
import { Pet } from "../Models/Pet";
import { PetService } from "../Services/PetService";

export const Pets = () => {

    const petService = new PetService();

    const pets: Array<Pet> = petService.getAll();

    const handleAdopt = (pet: Pet) => {
        console.log("Someone wants to adopt " + pet.name);
    }

    return (
        <Fragment>
            <Box>
                <Button>
                    <Link to="/">Go to the home page</Link>
                </Button>
            </Box>
            <Container>

                <Grid container spacing={4}>
                    {
                        pets.map((pet) => (
                            <Grid item key={pet.id} xs={12} sm={6} md={4}>
                                <PetCard pet={pet} handleAdopt={() => handleAdopt(pet)}></PetCard>
                            </Grid>
                        ))
                    }
                </Grid>
            </Container>
        </Fragment>
    );
}
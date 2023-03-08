import { Button, Card, CardActions, CardContent, CardMedia, Tooltip, Typography } from "@mui/material";
import { Pet } from "../Models/Pet";
import Diversity1Icon from '@mui/icons-material/Diversity1';

export interface IPetCardProps {
    pet: Pet;
    handleAdopt: any;
}

export const PetCard = (props: IPetCardProps) => {
    return (
        <Card sx={{ maxWidth: 345 }}>
            <CardMedia
                sx={{ height: 140 }}
                image={props.pet.imageUrl}
                title={props.pet.name}
            />
            <CardContent>
                <Typography gutterBottom variant="h5" component="div">
                    {props.pet.name} &nbsp;
                    {
                        props.pet.adopter &&
                        <Tooltip title={`${props.pet.name} found a home already.`}><Diversity1Icon></Diversity1Icon></Tooltip>
                    }
                </Typography>
                <Typography variant="body2" color="text.secondary">
                    {props.pet.description}
                </Typography>
            </CardContent>
            <CardActions sx={{ float: "right" }}>
                <Button size="small">Learn More</Button>
                {
                    props.pet.adopter
                        ? null
                        : <Button size="small" color='primary' variant="contained" onClick={props.handleAdopt}>Adopt</Button>
                }
            </CardActions>
        </Card>
    );
}
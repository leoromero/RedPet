import React from 'react';
import { Grid, Typography, Button } from '@material-ui/core';
import Styles from './Styles';
import { Link } from 'react-router-dom';

const Hero = (props) => {
    const classes = Styles();
    return (
        <Grid container className={classes.hero} >
            <Grid container className={classes.content}>
                <Grid container direction="column" alignItems="center" item xs={12} sm={6}>
                    <Typography variant="h5" color="textPrimary">Bienvenido a RedPet</Typography>
                    <Typography variant="h5" color="textPrimary">La red de servicios para mascoras</Typography>
                    <Typography variant="h5" color="textPrimary">mas grande de Ecuador</Typography>
                </Grid>
                <Grid container direction="column" alignItems="center" justify="center" item xs={12} sm={6}>
                    <Typography variant="h5">Imagen</Typography>
                </Grid>
                <Grid container direction="column" alignItems="center" item xs={12} sm={6}>
                    <Button variant="contained" component={Link} to='/login' size="large" color="secondary">Inicia sesión</Button>
                    <Grid container item direction="row" justify="center" alignItems="center">
                        <Typography variant="subtitle1" align="center">Ó </Typography>
                        <Button component={Link} to='/register' variant="text" color="secondary">Registrate</Button>
                        <Typography variant="subtitle1">, es gratis! </Typography>
                    </Grid>
                </Grid>
            </Grid>
        </Grid>
    );

}

export default Hero;
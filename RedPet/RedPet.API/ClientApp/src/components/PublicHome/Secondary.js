import React from 'react';
import { Grid, Typography, Button } from '@material-ui/core';
import Styles from './Styles';

const Secondary = (props) => {
    const classes = Styles();
    return (
        <Grid container className={classes.secondary}>
            <Grid container justify="center" item className={classes.content}>
                <Typography color="textSecondary" variant="h4" align="center" >Todo lo que tu mascota necesita en un solo lugar. </Typography>
                <Typography color="textSecondary" variant="h4" align="center" >Guardería, hospedaje, peluquería, alimento, y mucho mas... </Typography>
            </Grid>
        </Grid>
    );
}

export default Secondary;
import React from 'react';
import { Grid, Typography } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';
import Service from './Service';
import Styles from './Styles';

const Services = (props) => {
    const classes = Styles();
    return (
        <Grid id="services" container direction="column" item xs={12} className={classes.content}>
            <Grid item><Typography color="secondary" variant='h4' align="center">Servicios</Typography></Grid>
            <Grid container direction="row" item xs={12} className={classes.content}>
                <Grid item xs={12} sm={6} lg={3}>
                    <Service imagePosition="top" serviceName="Paseos" serviceDescription="Cuando no tengas tiempo de pasear a tu mascota, pide ayuda a un paseador de RedPet, tu perrito te lo agradecerá." image=''></Service>
                </Grid>
                <Grid item xs={12} sm={6} lg={3}>
                    <Service imagePosition="bottom" serviceName="Guardería" serviceDescription="Tu perrito estará bajo observación, bien cuidado y con la cuota de diversión y socialización necesaria mientras tu estas ocupado con tus actividades." image=''></Service>
                </Grid>
                <Grid item xs={12} sm={6} lg={3}>
                    <Service imagePosition="top" serviceName="Peluquería" serviceDescription="Cuando tu mascota necesite un baño o corte de pelo, nuestros peluqueros estarán esperándolo para brindarle el servicio que se merece." image=''></Service>
                </Grid>
                <Grid item xs={12} sm={6} lg={3}>
                    <Service imagePosition="bottom" serviceName="Alojamiento" serviceDescription="Cuando tengas que ir de viaje, tu mascota podrá quedarse en casa de un paseador quien lo cuidara como a su propia mascota." image=''></Service>
                </Grid>
            </Grid>
        </Grid>
    );

}

export default Services;
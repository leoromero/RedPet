import React from 'react';
import { Grid, Typography, Card, CardHeader, CardMedia, CardContent } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';
import styles from '../../styles/styles';

const Service = (props) => {
    return (
        <Card>
            <CardHeader title={props.serviceName} titleTypographyProps={{ color: "textSecondary", align: 'center' }}></CardHeader>
            {
                props.imagePosition == 'top' &&
                <CardMedia image={props.image} title={props.serviceName} title="imagen" component='img'></CardMedia>
            }
            <CardContent><Typography color="textSecondary" paragraph>{props.serviceDescription}</Typography></CardContent>
            {
                props.imagePosition == 'bottom' &&
                <CardMedia image={props.image} title={props.serviceName} title="imagen" component='img'></CardMedia>
            }
       </Card>
    );
}

export default Service;
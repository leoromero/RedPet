import React from 'react';
import { Typography, Card, CardHeader, CardMedia, CardContent } from '@material-ui/core';
import Styles from './Styles';


const Service = (props) => {
    const classes = Styles();
    return (
        <Card>
            <CardHeader title={props.serviceName} titleTypographyProps={{ color: "textPrimary", align: 'center' }}></CardHeader>
            {
                props.imagePosition == 'top' &&
                <CardMedia image={props.image} title={props.serviceName} title="imagen" component='img'></CardMedia>
            }
            <CardContent><Typography color="textPrimary" paragraph className={classes.TextAlignCenter}>{props.serviceDescription}</Typography></CardContent>
            {
                props.imagePosition == 'bottom' &&
                <CardMedia image={props.image} title={props.serviceName} title="imagen" component='img'></CardMedia>
            }
        </Card>
    );
}

export default Service;
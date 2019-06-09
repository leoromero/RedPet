import React, { useContext } from 'react';
import { Grid } from '@material-ui/core';
import Login from './Login';
import styles from '../../styles/styles';
import { AuthContext } from '../../contexts/AuthContext';
import { Redirect } from 'react-router';

const LoginPage = (props) => {

    const classes = styles();
    return (
        <Grid container justify='center' alignItems='center' className={classes.page}>
            <Grid item xs={8} md={6}>
                <Login></Login>
            </Grid>
        </Grid>
    );
}
export default LoginPage;
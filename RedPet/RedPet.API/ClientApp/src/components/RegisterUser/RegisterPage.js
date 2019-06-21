import React, { useContext } from 'react';
import { Grid } from '@material-ui/core';
import Register from './Register';
import styles from '../../styles/styles';
import { AuthContext } from '../../contexts/AuthContext';
import { Redirect } from 'react-router';
import { withRouter } from 'react-router-dom';

const RegisterPage = (props) => {

    const role = props.match.params.role;

    const classes = styles();
    return (
        <Grid container justify='center' alignItems='center' className={classes.page}>
            <Grid item xs={12} md={6}>
                <Register role={role}></Register>
            </Grid>
        </Grid>
    );
}
export default withRouter(RegisterPage);
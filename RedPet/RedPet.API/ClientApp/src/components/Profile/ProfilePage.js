import React, { useContext } from 'react';
import { Grid } from '@material-ui/core';
import styles from '../../styles/styles';
import { AuthContext } from '../../contexts/AuthContext';
import Profile from './Profile';

const ProfilePage = (props) => {

    const classes = styles();
    return (
        <Grid container justify='center' alignItems='center' className={classes.page}>
            <Grid item xs={12} md={6}>
                <Profile />
            </Grid>
        </Grid>
    );
}
export default ProfilePage;
import React from 'react';
import { Grid } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';
import styles from '../../styles/styles';
import Hero from './Hero';

const PublicHome = (props) => {
  const classes = styles();
    return (
      <Grid container className={classes.page}>
        <Grid item xs={12} md={12}>
          <Hero id="main" />
        </Grid>
      </Grid>
    );

}

export default PublicHome;
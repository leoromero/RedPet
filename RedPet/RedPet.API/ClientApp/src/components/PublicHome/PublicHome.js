import React from 'react';
import { Grid, Divider } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';
import styles from '../../styles/styles';
import Hero from './Hero';
import Secondary from './Secondary';
import Services from './Services';

const PublicHome = (props) => {
  const classes = styles();
    return (
      <Grid container className={classes.page}>
        <Grid item xs={12} md={12}>
          <Hero id="main" />
          <Secondary />
          <Divider variant='middle' />
          <Services/>
        </Grid>
      </Grid>
    );

}

export default PublicHome;
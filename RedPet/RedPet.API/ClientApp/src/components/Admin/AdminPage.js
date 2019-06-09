import React, { useContext, useEffect } from 'react';
import { Card, Grid } from '@material-ui/core';
import styles from '../../styles/styles';
import { AuthContext } from '../../contexts/AuthContext';
import { Redirect } from 'react-router-dom';
import { withRouter } from 'react-router-dom';

const AdminPage = (props) => {
  const classes = styles();
  const { user } = useContext(AuthContext);

  return (
    <Grid container justify='center' alignItems='center' className={classes.page} >
      <Grid item xs={12} md={10} lg={8}>
      </Grid>
    </Grid >
  );
};

export default withRouter(AdminPage);
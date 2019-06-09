import React, { useContext, useEffect } from 'react';
import { Card, Grid } from '@material-ui/core';
import PetForm from './PetForm';
import styles from '../../styles/styles';
import { AuthContext } from '../../contexts/AuthContext';
import { Redirect } from 'react-router-dom';
import { withRouter } from 'react-router-dom';

const PetPage = (props) => {
  const classes = styles();
  const { authenticated } = useContext(AuthContext);

  const petId = props.match.params.id;

  return (
    <Grid container justify='center' alignItems='center' className={classes.page} >
      <Grid item xs={12} md={10} lg={8}>
        <Card >
          <PetForm petId={petId}></PetForm>
        </Card>
      </Grid>
    </Grid >
  );
};

export default withRouter(PetPage);
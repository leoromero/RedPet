import React, { useContext, useState, useEffect } from 'react';
import { Card, Grid, Fab, Typography } from '@material-ui/core';
import PetForm from './PetForm';
import styles from '../../styles/styles';
import { AuthContext } from '../../contexts/AuthContext';
import { Redirect } from 'react-router-dom';
import { Add as AddIcon } from '@material-ui/icons';
import { withRouter } from 'react-router-dom';
import { MessageContext } from '../../contexts/MessageContext';
import useApi from '../../Hooks/useApi';
import Api from '../../helpers/Api';
import PetCard from './PetCard';
import { isNullOrUndefined } from 'util';

const PetsPage = (props) => {
  const classes = styles();
  const { user } = useContext(AuthContext);
  const showMessage = useContext(MessageContext);
  const [pets, setPets] = useState(undefined);

  useEffect(() => {
    const apiCall = async () => {
      const apiResponse = await useApi(Api.customers.pets(user.id), showMessage);

      if (apiResponse.ok) {
        apiResponse.result.length > 0 &&
          setPets(apiResponse.result);
      }
    };

    apiCall();
  }, []);

  const handleAdd = () => {
    props.history.push('/pets/new');
  };

  if(pets === undefined) return null;

  return (
    <Grid container justify='center' alignItems='center' className={classes.page} >
      <Grid item xs={12}>
        {         
            pets.length > 0 ? 
              pets.map((pet) =>
                <Grid item xs={12} md={6} lg={4}>
                  <PetCard id={pet.id} name={pet.name} breed={pet.breed.name} birthDate={pet.birthDate} gender={pet.gender}></PetCard>
                </Grid>
               ) :
              <Typography variant='subtitle1'>Todavia no tienes mascotas registradas.</Typography>
        }
        <Fab color="primary" aria-label="Add" className={classes.fab} onClick={handleAdd}>
          <AddIcon />
        </Fab>
      </Grid>
    </Grid >
  );
};

export default withRouter(PetsPage);
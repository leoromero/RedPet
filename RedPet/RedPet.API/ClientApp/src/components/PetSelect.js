import React, { useEffect, useState, useContext } from 'react';
import { FormControl, InputLabel, Select, MenuItem, FormHelperText } from '@material-ui/core';
import Api from '../helpers/Api';
import useApi from '../Hooks/useApi';
import { MessageContext } from '../contexts/MessageContext';
import { makeStyles } from '@material-ui/styles';
import styles from '../styles/styles';
import { AuthContext } from '../contexts/AuthContext';

const PetSelect = (props) => {

  const [pets, setPets] = useState([]);
  const { user } = useContext(AuthContext);
  const showMessage = useContext(MessageContext);

  useEffect(() => {
    const apiCall = async () => {
      const apiResponse = await useApi(Api.customers.pets(user.id), showMessage);

      if (apiResponse.ok) {
        setPets(apiResponse.result);
      }
    };
    apiCall();
  }, []);

  const classes = styles();
  return (
    <FormControl error={props.error} className={props.formControlClasses || classes.formControl}>
      <InputLabel htmlFor="pet.id" shrink={Boolean(props.value && true)}>Mascota</InputLabel>
      <Select
        value={props.value}
        onChange={(e) => props.onChange(e)}
        inputProps={{
          name: 'pet.id',
          id: 'pet.id'
        }}
      >
        {pets.map((pet, index) =>
          <MenuItem key={index} value={pet.id}>{pet.name}</MenuItem>
        )}
      </Select>
      {props.helperText && <FormHelperText>{props.helperText}</FormHelperText>}
    </FormControl>
  );
};

export default PetSelect;
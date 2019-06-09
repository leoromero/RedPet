import React, { useEffect, useState, useContext } from 'react';
import { FormControl, InputLabel, Select, MenuItem, FormHelperText, Hidden } from '@material-ui/core';
import Api from '../helpers/Api';
import useApi from '../Hooks/useApi';
import { MessageContext } from '../contexts/MessageContext';
import { makeStyles } from '@material-ui/styles';
import styles from '../styles/styles';

const BreedSelect = (props) => {
  
  const [breeds, setBreeds] = useState([]);
  const showMessage = useContext(MessageContext);

  useEffect(() => {
    const apiCall = async () => {
    const apiResponse = await useApi(Api.parameters.breeds(), showMessage);

    if(apiResponse.ok){       
      setBreeds(apiResponse.result);
    }
  };
  apiCall();
  }, []);

  const classes = styles();
    return( 
      <FormControl error={props.error} className={props.formControlClasses || classes.formControl}>
        <InputLabel htmlFor="breed.id" shrink={Boolean(props.value && true)}>Raza</InputLabel>
        <Select
          value={props.value}
          onChange={(e) => props.onChange(e)}
          inputProps={{
            name: 'breed.id',
            id: 'breed.id'
          }}
        >
          {breeds.map((breed, index)=> 
            <MenuItem key={index} value={breed.id}>{breed.name}</MenuItem>
          )}
        </Select>
        {props.helperText && <FormHelperText>{props.helperText}</FormHelperText>}        
      </FormControl>
        );
};
  
  export default BreedSelect;
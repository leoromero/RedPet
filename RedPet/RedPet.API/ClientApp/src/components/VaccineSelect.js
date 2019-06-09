import React, { useEffect, useState, useContext } from 'react';
import { FormControl, InputLabel, Select, MenuItem } from '@material-ui/core';
import Api from '../helpers/Api';
import useApi from '../Hooks/useApi';
import { MessageContext } from '../contexts/MessageContext';
import styles from '../styles/styles';

const VaccineSelect = (props) => {
  
  const [vaccines, setVaccines] = useState([]);
  const showMessage = useContext(MessageContext);

  useEffect(() => {
    const apiCall = async () => {
    const apiResponse = await useApi(Api.parameters.vaccines(), showMessage);
    if(apiResponse.ok){       
      setVaccines(apiResponse.result);
    }
  };

  apiCall();
  }, []);

  const classes = styles();
    return( 
      <FormControl className={props.formControlClasses || classes.formControl}>
        <InputLabel htmlFor={props.name} shrink={props.value && true}>Vacuna</InputLabel>
        <Select required
          value={props.value}
          onChange={props.onChange}
          inputProps={{
            name: props.name,
            id: 'size'
          }}
        >
          {vaccines.map((vaccine, index)=> 
            <MenuItem key={index} value={vaccine.id}>{vaccine.name}</MenuItem>
          )}
        </Select>
      </FormControl>
        );
};
  
  export default VaccineSelect;
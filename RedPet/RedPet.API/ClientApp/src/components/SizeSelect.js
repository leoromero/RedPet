import React, { useEffect, useState, useContext } from 'react';
import { FormControl, InputLabel, Select, MenuItem, FormHelperText } from '@material-ui/core';
import Api from '../helpers/Api';
import useApi from '../Hooks/useApi';
import { MessageContext } from '../contexts/MessageContext';
import { makeStyles } from '@material-ui/styles';
import styles from '../styles/styles';

const SizeSelect = (props) => {
  
  const [sizes, setSizes] = useState([]);
  const showMessage = useContext(MessageContext);

  useEffect(() => {
    const apiCall = async () => {
    const apiResponse = await useApi(Api.parameters.petSizes(), showMessage);

    if(apiResponse.ok){       
      setSizes(apiResponse.result);
    }
  };
  apiCall();
  }, []);

  const classes = styles();
    return( 
      <FormControl error={props.error} className={props.formControlClasses || classes.formControl}>
        <InputLabel htmlFor="petSize.id" shrink={Boolean(props.value && true)}>Tamaño</InputLabel>
        <Select
          value={props.value}
          onChange={(e) => props.onChange(e)}
          inputProps={{
            name: 'petSize.id',
            id: 'petSize.id'
          }}
        >
          {sizes.map((petSize, index)=> 
            <MenuItem key={index} value={petSize.id}>{petSize.name}</MenuItem>
          )}
        </Select>
        {props.helperText && <FormHelperText>{props.helperText}</FormHelperText>}
      </FormControl>
        );
};
  
  export default SizeSelect;
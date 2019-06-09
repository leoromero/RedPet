import React, { useEffect, useState, useContext } from 'react';
import { FormControl, InputLabel, Select, MenuItem, FormHelperText } from '@material-ui/core';
import Api from '../helpers/Api';
import useApi from '../Hooks/useApi';
import { MessageContext } from '../contexts/MessageContext';
import styles from '../styles/styles';

const ServiceSelect = (props) => {

  const [Services, setServices] = useState([]);
  const showMessage = useContext(MessageContext);

  useEffect(() => {
    const apiCall = async () => {
      const apiResponse = await useApi(Api.Services.read(), showMessage);

      if (apiResponse.ok) {
        setServices(apiResponse.result);
      }
    };
    apiCall();
  }, []);

  const classes = styles();
  return (
    <FormControl error={props.error} className={props.formControlClasses || classes.formControl}>
      <InputLabel htmlFor="Service.id" shrink={Boolean(props.value && true)}>Servicio</InputLabel>
      <Select
        value={props.value}
        onChange={(e) => props.onChange(e)}
        inputProps={{
          name: 'Service.id',
          id: 'Service.id'
        }}
      >
        {
          Services.map((Service, index) =>
            <MenuItem key={index} value={Service.id}>{Service.name}</MenuItem>
          )
        }
      </Select>
      {props.helperText && <FormHelperText>{props.helperText}</FormHelperText>}
    </FormControl>
  );
};

export default ServiceSelect;
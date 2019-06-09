import React, { useState, useContext, useEffect } from 'react';
import { FormControl, InputLabel, Select, MenuItem, FormHelperText } from '@material-ui/core';
import { MessageContext } from '../contexts/MessageContext';
import Api from '../helpers/Api';
import useApi from '../Hooks/useApi';
import styles from '../styles/styles';

const HairTypeSelect = (props) => {
  const classes = styles();
  const [hairTypes, setHairTypes] = useState([]);
  const showMessage = useContext(MessageContext);

  useEffect(() => {
    const apiCall = async () => {
      const apiResponse = await useApi(Api.parameters.hairTypes(), showMessage);

      if (apiResponse.ok) {
        setHairTypes(apiResponse.result);
      }
    };

    apiCall();
  }, []);

  return (
    <FormControl error={props.error} className={props.formControlClasses || classes.formControl}>
      <InputLabel htmlFor="hairType" shrink={Boolean(props.value && true)}>Tipo de pelo</InputLabel>
      <Select
        value={props.value}
        onChange={(e) => props.onChange(e)}
        inputProps={{
          name: 'hairType',
          id: 'hairType',
        }}
      >
        {hairTypes.map((type, index) =>
          <MenuItem key={index} value={type.id}>{type.name}</MenuItem>
        )}
      </Select>
        {props.helperText && <FormHelperText>{props.helperText}</FormHelperText>}
    </FormControl>
  );
};

export default HairTypeSelect;
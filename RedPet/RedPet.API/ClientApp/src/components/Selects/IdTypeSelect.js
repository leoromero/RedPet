import React, { useEffect, useState, useContext } from 'react';
import { FormControl, InputLabel, Select, MenuItem, FormHelperText } from '@material-ui/core';
import Api from '../../helpers/Api';
import useApi from '../../Hooks/useApi';
import { MessageContext } from '../../contexts/MessageContext';
import styles from '../../styles/styles';

const IdTypeSelect = (props) => {

  const [idTypes, setIdTypes] = useState([]);
  const showMessage = useContext(MessageContext);

  useEffect(() => {
    const apiCall = async () => {
      const apiResponse = await useApi(Api.parameters.idTypes(), showMessage);

      if (apiResponse.ok) {
        setIdTypes(apiResponse.result);
      }
    };
    apiCall();
  }, []);

  const classes = styles();
  return (
    <FormControl error={props.error} className={props.formControlClasses || classes.formControl}>
      <InputLabel htmlFor={props.id} shrink={Boolean(props.value && true)}>Tipo Identificación</InputLabel>
      <Select
        value={props.value}
        onChange={(e) => props.onChange(e)}
        inputProps={{
          name: props.name,
          id: props.id
        }}
      >
        {idTypes.map((idType, index) =>
          <MenuItem key={index} value={idType.id}>{idType.name}</MenuItem>
        )}
      </Select>
      {props.helperText && <FormHelperText>{props.helperText}</FormHelperText>}
    </FormControl>
  );
};

export default IdTypeSelect;
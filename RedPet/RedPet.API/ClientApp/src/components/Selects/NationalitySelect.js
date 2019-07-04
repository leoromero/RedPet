import React, { useEffect, useState, useContext } from 'react';
import { FormControl, InputLabel, Select, MenuItem, FormHelperText } from '@material-ui/core';
import Api from '../../helpers/Api';
import useApi from '../../Hooks/useApi';
import { MessageContext } from '../../contexts/MessageContext';
import styles from '../../styles/styles';

const NationalitySelect = (props) => {

  const [nationalities, setNationalities] = useState([]);
  const showMessage = useContext(MessageContext);

  useEffect(() => {
    const apiCall = async () => {
      const apiResponse = await useApi(Api.parameters.nationalities(), showMessage);

      if (apiResponse.ok) {
        setNationalities(apiResponse.result);
      }
    };
    apiCall();
  }, []);

  const classes = styles();
  return (
    <FormControl error={props.error} className={props.formControlClasses || classes.formControl}>
      <InputLabel htmlFor={props.id} shrink={Boolean(props.value && true)}>Nacionalidad</InputLabel>
      <Select
        value={props.value}
        onChange={(e) => props.onChange(e)}
        inputProps={{
          name: props.name,
          id: props.id
        }}
      >
        {nationalities.map((nationality, index) =>
          <MenuItem key={index} value={nationality.id}>{nationality.nation}</MenuItem>
        )}
      </Select>
      {props.helperText && <FormHelperText>{props.helperText}</FormHelperText>}
    </FormControl>
  );
};

export default NationalitySelect;
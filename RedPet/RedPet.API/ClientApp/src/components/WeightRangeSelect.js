import React, { useEffect, useState, useContext } from 'react';
import { FormControl, InputLabel, Select, MenuItem, FormHelperText } from '@material-ui/core';
import Api from '../helpers/Api';
import useApi from '../Hooks/useApi';
import { MessageContext } from '../contexts/MessageContext';
import styles from '../styles/styles';

const WeightRangeSelect = (props) => {
  
  const [weightRanges, setWeightRanges] = useState([]);
  const showMessage = useContext(MessageContext);

  useEffect(() => {
    const apiCall = async () => {
    const apiResponse = await useApi(Api.parameters.weightRanges(), showMessage);

    if(apiResponse.ok){       
      setWeightRanges(apiResponse.result);
    }
  };
  apiCall();
  }, []);

  const classes = styles();
    return( 
      <FormControl error={props.error} className={props.formControlClasses || classes.formControl}>
        <InputLabel htmlFor="weightRange.id" shrink={Boolean(props.value && true)}>Peso</InputLabel>
        <Select
          value={props.value}
          onChange={(e) => props.onChange(e)}
          inputProps={{
            name: 'weightRange.id',
            id: 'weightRange.id'
          }}
        >
          {weightRanges.map((weightRange, index)=> 
            <MenuItem key={index} value={weightRange.id}>{weightRange.name}</MenuItem>
          )}
        </Select>
        {props.helperText && <FormHelperText>{props.helperText}</FormHelperText>}
      </FormControl>
        );
};
  
  export default WeightRangeSelect;
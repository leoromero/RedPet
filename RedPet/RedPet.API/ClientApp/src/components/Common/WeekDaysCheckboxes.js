import React from 'react';
import { Grid, FormControl, FormHelperText, FormLabel, FormGroup, FormControlLabel, Checkbox } from '@material-ui/core';
import styles from '../../styles/styles';

const WeekDaysCheckboxes = (props) => {

  const classes = styles();
  return (
    <FormControl error={props.error} component="fieldset">
      <FormLabel className={classes.centerText} component="legend" >{props.title}</FormLabel>
      <FormGroup row>
        <Grid item container justify="center">
          <FormControlLabel
            control={<Checkbox checked={props.values.monday} name="weekDays.monday" onChange={props.onChange} value="monday" />}
            label="L"
            labelPlacement="bottom"
            style={{margin:0}}
          />
          <FormControlLabel
            control={<Checkbox checked={props.values.tuesday} name="weekDays.tuesday" onChange={props.onChange} value="tuesday" />}
            label="M"
            labelPlacement="bottom"
            style={{margin:0}}
          />
          <FormControlLabel
            control={<Checkbox checked={props.values.wednesday} name="weekDays.wednesday" onChange={props.onChange} value="wednesday" />}
            label="M"
            labelPlacement="bottom"
            style={{margin:0}}
          />
          <FormControlLabel
            control={<Checkbox checked={props.values.thursday} name="weekDays.thursday" onChange={props.onChange} value="thursday" />}
            label="J"
            labelPlacement="bottom"
            style={{margin:0}}
          />
          <FormControlLabel
            control={<Checkbox checked={props.values.friday} name="weekDays.friday" onChange={props.onChange} value="friday" />}
            label="V"
            labelPlacement="bottom"
            style={{margin:0}}
          />
          <FormControlLabel
            control={<Checkbox checked={props.values.saturday} name="weekDays.saturday" onChange={props.onChange} value="saturday" />}
            label="S"
            labelPlacement="bottom"
            style={{margin:0}}
          />
          <FormControlLabel
            control={<Checkbox checked={props.values.sunday} name="weekDays.sunday" onChange={props.onChange} value="sunday" />}
            label="D"
            labelPlacement="bottom"
            style={{margin:0}}
          />
        </Grid>
      </FormGroup>
      <Grid item container justify="center">
        {props.helperText && <FormHelperText>{props.helperText}</FormHelperText>}
      </Grid>
    </FormControl>
  );
};

export default WeekDaysCheckboxes;
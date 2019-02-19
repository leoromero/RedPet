import React from 'react';
import { Container, Content, Form, View, Text } from 'native-base';
import DateTimePicker from './DateTimePicker';
import SizePicker from './SizePicker';
import NameInput from './NameInput';
import BreedPicker from './BreedPicker';

export default class PetForm extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      name: undefined,
      age: undefined,
      birthDate: undefined,
      breed: undefined,
      size: undefined
    };
  }

  onNameChange = (value) => {
    this.setState({name: value})
  };

  onSizeSelected = (value) => {
    this.setState({size: value})
  };

  onBirthDateChange = (value) => {
    const age = calculateAge(value);
    this.setState({birthDate: value, age: age});
  };

  onBreedSelected = (value) => {
    this.setState({breed: value});
  };
  render() {
    return (     
        <Container>
          <Content>
            <Form style={{marginRight:20, marginLeft:20}}>
              <NameInput onChange={this.onNameChange} />
              <BreedPicker onSelected={this.onBreedSelected} />
              <SizePicker onSelected={this.onSizeSelected} />
              <DateTimePicker 
                  mode='date'
                  title='Nacimiento'
                  onChange={this.onBirthDateChange}
                />
              
            </Form>
          </Content>
        </Container>
    );
  }
}

let calculateAge = (date) => {
  today_date = new Date();
  today_year = today_date.getFullYear();
  today_month = today_date.getMonth();
  today_day = today_date.getDate();
  age = today_year - date.getFullYear();

  if ( today_month < (date.getMonth() - 1))
  {
      age--;
  }
  if (((date.getMonth() - 1) == today_month) && (today_day < date.getDate()))
  {
      age--;
  }
  return age;
}
import React from 'react';
import { Container, Content, Form } from 'native-base';
import PetPicker from './PetPicker';
import DateTimePicker from './DateTimePicker';
import AddressInput from './AddressInput';

export default class ServiceBookingForm extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      date: undefined,
      time: undefined,
      address: undefined,
      pet: undefined
    };
  }

  onDateChange = (value) => {
    this.setState({date: value})
  };

  onTimeChange = (value) => {
    this.setState({time: value})
  };

  onAddressChange = (value) => {
    this.setState({address: value})
  };

  onPetSelected = (value) => {
    this.setState({pet: value});
  };

  render() {
    return (     
        <Container>
          <Content>
            <Form style={{marginRight:20, marginLeft:20}}>            
              <PetPicker onSelected={this.onPetSelected}/>
              <DateTimePicker 
                onChange = {this.onDateChange}
                mode='date'
                title='Fecha'/>
              <DateTimePicker
                onChange = {this.onTimeChange}
                mode='time'
                title='Hora' />
              <DateTimePicker
                onChange = {this.onTimeChange}
                mode='time'
                isVisible = {false}
                title='Regreso' />
              <AddressInput 
                onChange = {this.onAddressChange}/>
            </Form>
          </Content>
        </Container>
    );
  }
}
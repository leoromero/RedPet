import React from 'react';
import PetForm from '../../components/PetForm';

export default class PetScreen extends React.Component {
  static navigationOptions = {
    header: null
  };

  render() {
    return(
      <PetForm></PetForm>
    );
  }
}

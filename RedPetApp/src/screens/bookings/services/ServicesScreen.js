import React from 'react';
import InfoCardList from '../../../components/InfoCardList';

export default class ServicesScreen extends React.Component {
  static navigationOptions = {
    title: 'Services',
    header: null,
  };

  onPressButton = (obj) => {
    this.props.navigation.navigate('ServiceDetails', {'service':obj});
  };
    render() {
      return (
      <InfoCardList type='service' handleBookingPress={this.onPressButton}/>
    );}
  }
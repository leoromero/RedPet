import React from 'react';
import InfoCardList from '../../../components/InfoCardList';

export default class PromotionsScreen extends React.Component {
  static navigationOptions = {
    header: null
  };
  
  onPressButton = (id) => {
    this.props.navigation.navigate('ServiceDetails', {id:id});
  };
    render() {
      return (
      <InfoCardList type='promotion' handleBookingPress={this.onPressButton}/>
    );
  }
}
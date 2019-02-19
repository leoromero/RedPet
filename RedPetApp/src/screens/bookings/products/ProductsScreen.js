import React from 'react';
import InfoCardList from '../../../components/InfoCardList';

export default class ProductsScreen extends React.Component {
  static navigationOptions = {
    title: 'Products',
    header: null
  };
onPressButton = (id) => {
  this.props.navigation.navigate('ProductDetails', {id:id});
};
  render() {
    return (
    <InfoCardList type='product' handleBookingPress={this.onPressButton}/>
  );}
}

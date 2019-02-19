import React from 'react';
import { ScrollView, StyleSheet } from 'react-native';
import { ExpoLinksView } from '@expo/samples';
import ServiceBookingForm from '../../../components/ServiceBookingForm';

export default class ServiceDetailsScreen extends React.Component {  
  constructor(props){
    super(props)
  }

  static navigationOptions = ({ navigation }) => {
    return {
      title: navigation.getParam('service', 'Servicio').name,
    };
  };
  render() {
    return (
      <ServiceBookingForm service={this.props.navigation.getParam('service', 'Servicio')}></ServiceBookingForm>
    );
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    paddingTop: 15,
    backgroundColor: '#fff',
  },
});

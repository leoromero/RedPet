import React from 'react';
import { Container, Card, CardItem, Content, Body, Text, Left, Thumbnail, Right, Button, Footer, Icon, H1 } from 'native-base';

export default class InfoCard extends React.Component {

  handleBookingPress = () => {
    this.props.handleBookingPress();
  };

  render() {
    return (     
         <Card>
          <CardItem header bordered button onPress={this.props.handleBookingPress}>
           <Body>
            <H1 style={{alignSelf:"center"}}>{this.props.name}</H1>
           </Body> 
           <Right><Button dark rounded small onPress={this.props.handleBookingPress}><Text>Reservar</Text></Button></Right>        
          </CardItem>
           <CardItem bordered button onPress={this.props.handleBookingPress}>           
            <Left>
              <Thumbnail square source={require('../../assets/images/icon.png')}></Thumbnail>
            </Left>
            <Body style={{ flex:3 }}>
              <Text>
                {this.props.description}
              </Text>
            </Body>
           </CardItem>
         </Card>       
    );
  }
}
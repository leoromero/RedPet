import React from 'react';
import { Container, Card, CardItem, Content, Body, Text, Left, Thumbnail, Right, Button, Footer, Icon, H1 } from 'native-base';
import Api from '../common/Api';
import InfoCard from './InfoCard';

export default class InfoCardList extends React.Component {

  componentWillMount(){
    this.objects = this.fetchObjects();
  };

  fetchObjects = () => {
    switch(this.props.type)
    {
      case 'service':
        return Api.services().getAll();
      case 'product':
        return Api.products().getAll();
      case 'promotion':
        return Api.promotions().getAll();
    }
  };

  render() {
    const cards = this.objects.map((obj) => 
      <InfoCard
        key={obj.id.toString()}
        id={obj.id} 
        name={obj.name}
        description={obj.description}
        icon={obj.icon}
        handleBookingPress={() => this.props.handleBookingPress(obj)} />
    );

    return (
      <Container>
        <Content>        
            {cards}
        </Content>
      </Container>         
    );
  }
}
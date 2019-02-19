import React from 'react';
import { Picker, Item, Label, View, Icon, Button, Col, Row, Grid } from 'native-base';
import Api from '../common/Api';
import Styles from '../constants/Styles';
import { withNavigation } from 'react-navigation';

const pets = Api.loggedUser().pets;
const listItems = pets.map((pet) =>
<Picker.Item key={pet.id}
          value={pet.id}
          label={pet.name} />
);
class PetPicker extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      selected: undefined
    };
  }
  onValueChange = (value) => {
    if(value != 0)
      {
        this.setState({
          selected: value
        });
        this.props.onSelected(value);
      }
  };

onButtonPress = () => {
  this.props.navigation.navigate('NewPet');
};

  render() {
    return (   
      <Item style={Styles.Form.Item}>
        <View style={Styles.Form.Label}>
          <Label>Mascota</Label>
        </View>
        <View style={Styles.Form.Control}>
          <Picker
            note
            mode="dropdown"
            selectedValue={this.state.selected}
            onValueChange={this.onValueChange}
          >
            <Picker.Item key='0'
            value='0'
            label='Seleccione' />          
              {listItems}
          </Picker>
          <Button dark rounded small icon style={Styles.Form.CenteredButton} onPress={this.onButtonPress}><Icon type="Octicons" name='plus' /></Button>
        </View>
      </Item>      
    );
  }
}

export default withNavigation(PetPicker);
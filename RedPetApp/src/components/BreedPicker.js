import React from 'react';
import { Picker, Item, Label, View, Icon, Button, Col, Row, Grid } from 'native-base';
import Api from '../common/Api';
import Styles from '../constants/Styles';

const breeds = Api.breeds();
const listItems = breeds.map((breed) =>
<Picker.Item key={breed.id}
          value={breed.id}
          label={breed.name} />
);
export default class BreedPicker extends React.Component {
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

  render() {
    return (   
      <Item style={Styles.Form.Item}>
        <View style={Styles.Form.Label}>
          <Label>Raza</Label>
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
        </View>
      </Item>      
    );
  }
}
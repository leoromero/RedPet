import React from 'react';
import { Picker, Item, Label, View, Icon, Button, Col, Row, Grid } from 'native-base';
import Api from '../common/Api';
import Styles from '../constants/Styles';

const sizes = Api.sizes();
const listItems = sizes.map((size) =>
<Picker.Item key={size.id}
          value={size.id}
          label={size.name} />
);
export default class SizePicker extends React.Component {
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
          <Label>Tamaño</Label>
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
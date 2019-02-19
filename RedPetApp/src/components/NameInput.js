import React from 'react';
import { Item, Label, Input, View } from 'native-base';
import Styles from '../constants/Styles';

export default class NameInput extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      name: undefined
    };
  }
  onChangeText = (value) => {
    this.setState({
      name: value
    });
    this.props.onChange(value);
  };

  render() {
    return (   
      <Item inlineLabel style={Styles.Form.Item}>
      <View style={Styles.Form.Label}>
        <Label>Nombre</Label>
      </View>
      <View style={Styles.Form.Control}> 
        <Input multiline value={this.state.name} onChangeText={this.onChangeText} />
      </View>
      </Item>
    );
  }
}
import React from 'react';
import { Item, Label, Input, View } from 'native-base';
import Api from '../common/Api';
import Styles from '../constants/Styles';

const address = Api.loggedUser().address;
export default class AddressInput extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      address: address
    };
  }

  componentWillMount = () => {this.props.onChange(this.state.address)};
  onChangeText = (value) => {
    this.setState({
      address: value
    });
    this.props.onChange(value);
  };

  render() {
    return (   
      <Item inlineLabel style={Styles.Form.Item}>
      <View style={Styles.Form.Label}>
        <Label>Dirección</Label>
      </View>
      <View style={Styles.Form.Control}> 
        <Input multiline value={this.state.address} onChangeText={this.onChangeText} />
      </View>
      </Item>
    );
  }
}
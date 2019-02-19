import React, { Component } from 'react';
import {Text, Item, Button, Icon, Label, View } from 'native-base';
import {default as DT} from 'react-native-modal-datetime-picker';
import Styles from '../constants/Styles';

export default class DateTimePicker extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      isDateTimePickerVisible: false,
      text: undefined
      };
  }

static defaultProps = {
  isVisible: true
};

  _showDateTimePicker = () => this.setState({ isDateTimePickerVisible: true });

  _hideDateTimePicker = () => this.setState({ isDateTimePickerVisible: false });

  _handleDatePicked = (date) => {
    const datetime = new Date(date);
    const text = this.props.mode == 'time' ? `${datetime.toLocaleTimeString().substr(0,5)}` 
    : `${datetime.getDate()}/${datetime.getMonth() + 1}/${datetime.getFullYear()}`;
    this.setState({text: text });
    this.props.onChange(datetime);
    this._hideDateTimePicker();
  };

  render () {
    if(this.props.isVisible)
    {
      return (
        <Item style={Styles.Form.Item}>
          <View style={Styles.Form.Label}>
            <Label>{this.props.title}</Label>
          </View>
          <View style={Styles.Form.Control}>
            <Text style={Styles.Form.Text} onPress={this._showDateTimePicker}>{this.state.text}</Text>
            <Button small rounded dark icon onPress={this._showDateTimePicker}>
              <Icon name={this.props.mode == 'time' ? 'clock' : 'calendar'} />  
            </Button>
          </View>
          <DT
            isVisible={this.state.isDateTimePickerVisible}
            onConfirm={this._handleDatePicked}
            onCancel={this._hideDateTimePicker}
            mode={this.props.mode}
            datePickerModeAndroid = 'spinner'
          />
        </Item>
      );
    }
    else
    {
      return null;
    }
  }
}
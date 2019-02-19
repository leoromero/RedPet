import React from 'react';
import { Text, View, StyleSheet } from 'react-native';
import {Agenda} from 'react-native-calendars';

export default class CalendarScreen extends React.Component {
  constructor(props){
    super(props);
    this.state = {
      items: {'2019-02-01': [{text: 'item 1 - any js object'}],
    '2019-02-04': [{text: 'item 2 - any js object'}],
    '2019-03-03': [],
    '2019-02-05': [{text: 'item 3 - any js object'},{text: 'any js object'}],
   }};
  }
  static navigationOptions = {
    title: 'Calendar',
    header: null
  };

  render() {
    return (
      <Agenda
        items={this.state.items}
        loadItemsForMonth={this.loadItems.bind(this)}
        selected={'2019-02-04'}
        renderItem={this.renderItem.bind(this)}
        renderEmptyDate={this.renderEmptyDate.bind(this)}
        rowHasChanged={this.rowHasChanged.bind(this)}
        markingType='multi-period'
        markedDates={{
           '2019-02-14': {
             periods: [{startingDay: true, color: 'blue'}]
            },
           '2019-02-22':{
             periods: [ {endingDay: true, color: 'blue'}]
           }
        }}     
      />
    );
  }

  loadItems(day) {
    console.log(day);
    day = new Date(Date.UTC(day.year, day.month, 1));
    let month = day.getUTCMonth();
    for(let d = day; d.getUTCMonth() <  month + 1; d.setUTCDate(d.getUTCDate() + 1) )
    {
      let strTime = this.timeToString(d);
      if (!this.state.items[strTime]) {
        this.state.items[strTime] = [];
      }
    }
    const newItems = {};
    Object.keys(this.state.items).forEach(key => {newItems[key] = this.state.items[key];});
    this.setState({
      items: newItems
    }); 
  }

  renderItem(item) {
    return (
      <View style={[styles.item, {height: item.height}]}><Text>{item.name}</Text></View>
    );
  }

  renderEmptyDate() {
    return (
      <View style={styles.emptyDate}><Text>This is empty date!</Text></View>
    );
  }

  rowHasChanged(r1, r2) {
    return r1.name !== r2.name;
  }

  timeToString(time) {
    const date = new Date(time);
    return date.toISOString().split('T')[0];
  }
}

const styles = StyleSheet.create({
  item: {
    backgroundColor: 'white',
    flex: 1,
    borderRadius: 5,
    padding: 10,
    marginRight: 10,
    marginTop: 17
  },
  emptyDate: {
    height: 15,
    flex:1,
    paddingTop: 30
  }
});






  // render() {
  //   return <Agenda items={
  //     {'2019-02-01': [{text: 'item 1 - any js object'}],
  //      '2019-02-04': [{text: 'item 2 - any js object'}],
  //      '2019-03-03': [],
  //      '2019-02-05': [{text: 'item 3 - any js object'},{text: 'any js object'}],
  //     }}
  //     markedDates={
  //     {'2019-02-01': {selected: true, marked: true},
  //      '2019-02-04': {marked: true},
  //      '2019-03-03': {disabled: true}
  //     }}
  //     loadItemsForMonth={(month) => {console.log('trigger items loading')}}
  //     // callback that fires when the calendar is opened or closed
  //     onCalendarToggled={(calendarOpened) => {console.log(calendarOpened)}}
  //     // callback that gets called on day press
  //     onDayPress={(day)=>{console.log('day pressed')}}
  //     // callback that gets called when day changes while scrolling agenda list
  //     onDayChange={(day)=>{console.log('day changed')}}
  //     // Minimum date that can be selected, dates before minDate will be grayed out. Default = undefined
  //     minDate={'2012-05-10'}
  //     // Maximum date that can be selected, dates after maxDate will be grayed out. Default = undefined
  //     maxDate={'2019-05-30'}
  //     // Max amount of months allowed to scroll to the past. Default = 50
  //     pastScrollRange={50}
  //     // Max amount of months allowed to scroll to the future. Default = 50
  //     futureScrollRange={50}
  //     // specify how each item should be rendered in agenda
  //     renderItem={(item, firstItemInDay) => {return (<View />);}}
  //     // specify how each date should be rendered. day can be undefined if the item is not first in that day.
  //     renderDay={(day, item) => {return (<View />);}}
  //     // specify how empty date content with no items should be rendered
  //     renderEmptyDate={() => {return (<View />);}}
  //     // specify how agenda knob should look like
  //     renderKnob={() => {return (<View />);}}
  //     // specify what should be rendered instead of ActivityIndicator
  //     renderEmptyData = {() => {return (<View />);}}
  //     // specify your item comparison function for increased performance
  //     rowHasChanged={(r1, r2) => {return r1.text !== r2.text}}
  //     // Hide knob button. Default = false
  //     hideKnob={true}
  //     // If provided, a standard RefreshControl will be added for "Pull to Refresh" functionality. Make sure to also set the refreshing prop correctly.
  //     onRefresh={() => console.log('refreshing...')}
  //     // Set this true while waiting for new data from a refresh
  //     refreshing={false}
  //     // Add a custom RefreshControl component, used to provide pull-to-refresh functionality for the ScrollView.
  //     refreshControl={null}
  //     // agenda theme
  //     theme={{      
  //       agendaDayTextColor: 'yellow',
  //       agendaDayNumColor: 'green',
  //       agendaTodayColor: 'red',
  //       agendaKnobColor: 'blue'
  //     }}
  //     // agenda container style
  //     style={{}}
  //     ></Agenda>
  // }
//}





import { StyleSheet } from 'react-native';

export default {
    Form: StyleSheet.create(
        {
            Item: { height:60, flexDirection:'row'},
            CenteredButton: { alignSelf:'center' },
            Label: { flex:1 },
            Picker: { flex:2 },
            Text: { flex:2, marginLeft:5 },
            Input: { flex:2},
            Control: { flex:2, 
                flexDirection:'row', 
                alignItems:'center'
            }
        }
    )
};

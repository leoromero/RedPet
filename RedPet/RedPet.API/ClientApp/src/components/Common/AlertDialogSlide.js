import React from 'react';
import Button from '@material-ui/core/Button';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';
import Slide from '@material-ui/core/Slide';
import useOpen from '../../Hooks/useOpen';

function Transition(props) {
    return <Slide direction="up" {...props} />;
}

const AlertDialogSlide = (props) => {
    return (
        <div>
            <Dialog
                open={props.isOpen}
                TransitionComponent={Transition}
                keepMounted
                onClose={props.toggle}
                aria-labelledby="alert-dialog-slide-title"
                aria-describedby="alert-dialog-slide-description"
            >
                <DialogTitle id="alert-dialog-slide-title">
                    {props.title}
                </DialogTitle>
                <DialogContent>
                    <DialogContentText id="alert-dialog-slide-description">
                        {props.content}
                    </DialogContentText>
                </DialogContent>
                <DialogActions>
                    {props.actions}
                </DialogActions>
            </Dialog>
        </div>
    );
}

export default AlertDialogSlide;
//@flow
import { connect } from 'react-redux';
import type { HasChildren } from 'components/common';
import type { ModalDialogState } from 'models/modals';
import type { ModalWindowProps } from './ModalWindow';
import { ModalWindow } from './ModalWindow';
import type { ModalWidth } from './ModalWindow';

function mapStateToProps(state : { modalVisibility: ModalDialogState }, ownProps : HasChildren & { width : ModalWidth }) : ModalWindowProps {
    return {
        visible: state?.modalVisibility?.visible || false,
        children: ownProps?.children,
        width: ownProps?.width,
    };
}

const connectedModalWindow = connect<ModalWindowProps, any, any, any, any, any>(
    mapStateToProps
)(ModalWindow);
export { connectedModalWindow };
//@flow
import { connect } from 'react-redux';
import type { MovePanelType } from './ChangePanelProps';
import { ChangePanelButton } from './ChangePanelButton'
import type { ChangePanelProps } from './ChangePanelProps'
import { movePanels } from 'actions/pageLayout/ChangeActivePanel';

export type ConnectedChangePanelButtonProps = {
    type : MovePanelType
};

type EventProps = {
    onClick : () => void
};

function mapStateToProps(state : any, ownProps : ConnectedChangePanelButtonProps) : $Diff<ChangePanelProps,EventProps> {
    return {
        type: ownProps.type,
        activePanel: state.activePanel,
        recentlyChanged: state.recentlyChanged,
    };
}

const mapDispatchToProps = {
    onClick: movePanelsFunc,
};

function movePanelsFunc() {
    console.log('Move panels clicked.', this.type);
    return movePanels(this.type);
}

const connectedChangePanelButton = connect<ChangePanelProps,ConnectedChangePanelButtonProps, any, any, any, any>(
    mapStateToProps,
    mapDispatchToProps
)(ChangePanelButton);
export { connectedChangePanelButton };
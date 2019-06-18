//@flow
import { connect } from 'react-redux';
import type { MovePanelType, ChangePanelProps } from './ChangePanelProps';
import { Left, Right } from './ChangePanelProps'
import type { ActivePagePanel } from 'models/pageLayout';
import { NavigationPanel, AsidesPanel } from 'components/pageLayout';
import { ChangePanelButton } from './ChangePanelButton'
import { movePanels } from 'actions/pageLayout/ChangeActivePanel';


export type ConnectedChangePanelButtonProps = {
    type : MovePanelType
};

type EventProps = {
    onClick : () => void
};

function isButtonEnabled(type : MovePanelType, state : ?ActivePagePanel) {
    if(type === Left && state?.activePanel === NavigationPanel) return false;
    if(type === Right && state?.activePanel === AsidesPanel) return false;
    return true;
}

function mapStateToProps(state : { activePagePanel : ActivePagePanel }, ownProps : ConnectedChangePanelButtonProps) : $Diff<ChangePanelProps,EventProps> {
    return {
        type: ownProps.type,
        activePanel: state?.activePagePanel?.activePanel,
        recentlyChanged: state?.activePagePanel?.recentlyChanged,
        enabled: isButtonEnabled(ownProps.type, state?.activePagePanel),
    };
}

const mapDispatchToProps = {
    onClick: movePanelsFunc,
};

function movePanelsFunc() {
    return movePanels(this.type);
}

const connectedChangePanelButton = connect<ChangePanelProps,ConnectedChangePanelButtonProps, any, any, any, any>(
    mapStateToProps,
    mapDispatchToProps
)(ChangePanelButton);
export { connectedChangePanelButton };
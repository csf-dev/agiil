//@flow
import { connect } from 'react-redux';
import type { ActivePagePanel } from 'models/pageLayout';
import type { PanelName } from './PanelName';
import type { CurrentPanelButtonProps } from './CurrentPanelButton';
import { CurrentPanelButton } from './CurrentPanelButton';
import { openChangePanelDialog, closeChangePanelDialog, chooseNewPanelFromDialog } from 'actions/pageLayout/ChangeActivePanel';

type EventProps = {
    onClick : () => void,
    dismissModal: () => void,
    choosePanel: (panel : PanelName) => void,
};

function mapStateToProps(state : { activePagePanel : ActivePagePanel }) : $Diff<CurrentPanelButtonProps,EventProps> {
    return {
        activePanel: state?.activePagePanel?.activePanel,
        recentlyChanged: state?.activePagePanel?.recentlyChanged,
        choosePanelDialogVisible: state?.activePagePanel?.choosePanelDialogVisible,
    };
}

const mapDispatchToProps = {
    onClick: openChangePanelDialog,
    dismissModal: closeChangePanelDialog,
    choosePanel: chooseNewPanelFromDialog,
};

const connectedCurrentPanelButton = connect<CurrentPanelButtonProps, any, any, any, any, any>(
    mapStateToProps,
    mapDispatchToProps
)(CurrentPanelButton);
export { connectedCurrentPanelButton };
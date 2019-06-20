//@flow
import { connect } from 'react-redux';
import type { ActivePagePanel } from 'models/pageLayout';
import { CurrentPanelButton } from './CurrentPanelButton';
import type { CurrentPanelButtonProps } from './CurrentPanelButton';
import { openChangePanelDialog } from 'actions/pageLayout/ChangeActivePanel';

type EventProps = {
    onClick : () => void
};

function mapStateToProps(state : { activePagePanel : ActivePagePanel }) : $Diff<CurrentPanelButtonProps,EventProps> {
    return {
        activePanel: state?.activePagePanel?.activePanel,
        recentlyChanged: state?.activePagePanel?.recentlyChanged,
    };
}

const mapDispatchToProps = {
    onClick: openChangePanelDialog,
};

const connectedCurrentPanelButton = connect<CurrentPanelButtonProps, any, any, any, any, any>(
    mapStateToProps,
    mapDispatchToProps
)(CurrentPanelButton);
export { connectedCurrentPanelButton };
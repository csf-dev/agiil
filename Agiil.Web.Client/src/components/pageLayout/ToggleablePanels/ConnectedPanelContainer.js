//@flow
import { connect } from 'react-redux';
import { PanelContainer } from './PanelContainer';
import { MainPanel } from "./PanelName";
import type { PanelContainerProps } from './PanelContainer';
import type { HasChildren } from 'components';
import { movePanels } from 'actions/pageLayout/ChangeActivePanel';
import type { MovePanelType } from './ChangePanelProps';
import { Left, Right } from './ChangePanelProps'

type EventProps = {
    onSwipeLeft : () => void,
    onSwipeRight : () => void,
};

function mapStateToProps(state : any, ownProps : HasChildren) : $Diff<PanelContainerProps,EventProps> {
    return {
        children: ownProps.children,
        currentPanel: state.activePagePanel.activePanel || MainPanel,
        recentlyChanged : state.activePagePanel.recentlyChanged || false
    };
}

const swipeLeft = () => movePanels(Right);
const swipeRight = () => movePanels(Left);

const mapDispatchToProps = {
    onSwipeLeft: swipeLeft,
    onSwipeRight: swipeRight,
};

const connectedPanelContainer = connect<PanelContainerProps,HasChildren, any, any, any, any>(
    mapStateToProps,
    mapDispatchToProps,
)(PanelContainer);
export { connectedPanelContainer };
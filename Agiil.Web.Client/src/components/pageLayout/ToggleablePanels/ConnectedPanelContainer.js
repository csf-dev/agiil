//@flow
import { connect } from 'react-redux';
import { PanelContainer } from './PanelContainer';
import { MainPanel } from "./PanelName";
import type { PanelContainerProps } from './PanelContainer';
import type { HasChildren } from 'components';

function mapStateToProps(state : any, ownProps : HasChildren) : PanelContainerProps {
    return {
        children: ownProps.children,
        currentPanel: state.currentActivePagePanel || MainPanel
    };
}

const connectedPanelContainer = connect<PanelContainerProps,HasChildren, any, any, any, any>(
    mapStateToProps
)(PanelContainer);
export { connectedPanelContainer };
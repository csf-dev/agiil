//@flow
import { connect } from 'react-redux';
import * as React from "react";
import { PanelContainer } from './PanelContainer';
import type { PanelName } from "./PanelName";
import { MainPanel } from "./PanelName";
import type { PanelContainerProps } from './PanelContainer';

type ConnectedPanelContainerProps = {
    children? : Array<React$Node>
}

function mapStateToProps(state : any, ownProps : ConnectedPanelContainerProps) : PanelContainerProps {
    return {
        children: ownProps.children || [],
        currentPanel: state.currentActivePagePanel || MainPanel
    };
}

const connectedPanelContainer = connect<PanelContainerProps,ConnectedPanelContainerProps, any, any, any, any>(
    mapStateToProps
)(PanelContainer);
export default connectedPanelContainer;
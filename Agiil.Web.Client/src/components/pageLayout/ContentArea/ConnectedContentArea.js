//@flow
import { connect } from 'react-redux';
import * as React from "react";
import { ContentArea } from "./ContentArea";
import type { ContentAreaProps } from "./ContentArea";

type ConnectedContentAreaProps = {
    children? : Array<HTMLElement>
}

function mapStateToProps(state : any, ownProps : ConnectedContentAreaProps) : ContentAreaProps {
    return {
        children: ownProps.children || []
    };
}

const connectedContentArea = connect<ContentAreaProps,ConnectedContentAreaProps, any, any, any, any>(
    mapStateToProps
)(ContentArea);
export default connectedContentArea;
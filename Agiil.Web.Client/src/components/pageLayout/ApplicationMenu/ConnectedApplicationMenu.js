//@flow
import { connect } from 'react-redux';
import * as React from "react";
import { ApplicationMenu } from "./ApplicationMenu";
import type { ApplicationMenuProps } from "./ApplicationMenu";

type ConnectedApplicationMenuProps = {
    children? : Array<HTMLElement>
}

function mapStateToProps(state : any, ownProps : ConnectedApplicationMenuProps) : ApplicationMenuProps {
    return {
        children: ownProps.children || []
    };
}

const connectedApplicationMenu = connect<ApplicationMenuProps,ConnectedApplicationMenuProps, any, any, any, any>(
    mapStateToProps
)(ApplicationMenu);
export default connectedApplicationMenu;
//@flow
import * as React from "react";
import type { HasChildren } from 'components';

export function MainContent(props : HasChildren) {
    return (
        <div className="main_content">
            {props.children}
        </div>
    )
}
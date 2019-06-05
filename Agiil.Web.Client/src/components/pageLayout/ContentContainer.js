//@flow
import * as React from "react";
import type { HasChildren } from 'components';

export function ContentContainer(props : HasChildren) {
    return (
        <div className="content_container">
            {props.children}
        </div>
    );
}
//@flow
import * as React from "react";
import type { HasChildren } from 'components';

export function ContentHeader(props : HasChildren) {
    return (
        <header className="content_header">
            {props.children}
        </header>
    );
}

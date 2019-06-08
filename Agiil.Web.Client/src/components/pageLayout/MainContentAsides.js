//@flow
import * as React from "react";
import type { HasChildren } from 'components';

export function MainContentAsides(props : HasChildren) {
    return (
        <aside className="main_content_asides">
            {props.children}
        </aside>
    );
}
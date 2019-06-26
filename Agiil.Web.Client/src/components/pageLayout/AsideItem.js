//@flow
import * as React from "react";
import type { HasChildren } from 'components';

export function AsideItem(props : HasChildren) {
    return (
        <div className="aside_item">
            {props.children}
        </div>
    );
}
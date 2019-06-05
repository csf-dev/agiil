//@flow
import * as React from "react";
import type { HasChildren } from 'components';

export function ContentArea(props : HasChildren) {
    return (
        <section className="content_area">
            {props.children}
        </section>
    );
}

//@flow
import * as React from "react";
import { getElementsHtml } from 'util/dom';

export type ContentAreaProps = {
    children : Array<HTMLElement>
};

export function ContentArea(props : ContentAreaProps) {
    return (
        <section className="content_area"
                 dangerouslySetInnerHTML={getElementsHtml(props.children)} />
    );
}
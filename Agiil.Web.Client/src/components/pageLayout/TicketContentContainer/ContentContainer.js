//@flow
import * as React from "react";
import { getElementsHtml } from 'util/dom';

export type ContentContainerProps = {
    children : Array<HTMLElement>
};

export function ContentContainer(props : ContentContainerProps) {
    return (
        <div className="content_container"
             dangerouslySetInnerHTML={getElementsHtml(props.children)} />
    );
}
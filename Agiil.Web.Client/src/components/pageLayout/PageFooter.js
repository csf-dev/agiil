//@flow
import * as React from "react";
import { getElementsHtml } from 'util/dom';

export type PageFooterProps = {
    children : Array<HTMLElement>
};

export function PageFooter(props : PageFooterProps) {
    return (
        <footer className="standard PageFooter"
                dangerouslySetInnerHTML={getElementsHtml(props.children)} />
    );
}
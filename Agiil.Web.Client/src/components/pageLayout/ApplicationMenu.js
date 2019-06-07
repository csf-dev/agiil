//@flow
import * as React from "react";
import { getElementsHtml } from 'util/dom';

export type ApplicationMenuProps = {
    children : Array<HTMLElement>
};

export function ApplicationMenu(props : ApplicationMenuProps) {
    return (
        <nav className="application_menu"
             dangerouslySetInnerHTML={getElementsHtml(props.children)} />
    );
}
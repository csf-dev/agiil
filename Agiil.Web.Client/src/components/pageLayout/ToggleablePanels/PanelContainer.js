//@flow
import * as React from "react";
import type { PanelName } from "./PanelName";
import { NavigationPanel, MainPanel, AsidesPanel } from "./PanelName";
import { getElementsHtml } from 'util/dom';

export type PanelContainerProps = {|
    currentPanel : ?PanelName,
    children : Array<HTMLElement>
|};

export function PanelContainer(props : PanelContainerProps) {
    return (
        <div className={getClassName(props.currentPanel)}
             dangerouslySetInnerHTML={getElementsHtml(props.children)} />
    );
}

const
    pageAreaClass = 'page_area',
    navPanelActiveClass = 'app_nav_panel_active',
    asidesPanelActiveClass = 'asides_panel_active',
    mainPanelActiveClass = '';

function getClassName(currentPanel : ?PanelName) {
    const classes = [pageAreaClass];

    switch(currentPanel)
    {
    case NavigationPanel:
        classes.push(navPanelActiveClass);
        break;
    case MainPanel:
        classes.push(mainPanelActiveClass);
        break;
    case AsidesPanel:
        classes.push(asidesPanelActiveClass);
        break;
    }

    return classes.join(' ');
}

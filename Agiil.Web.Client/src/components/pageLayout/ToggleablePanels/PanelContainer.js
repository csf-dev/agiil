//@flow
import * as React from "react";
import type { PanelName } from "./PanelName";
import { NavigationPanel, MainPanel, AsidesPanel } from "./PanelName";
import { getElementsHtml } from 'util/dom';
import type { HasChildren } from 'components';

export type PanelContainerProps = {
    currentPanel : ?PanelName,
    recentlyChanged : bool
} & HasChildren;

export function PanelContainer(props : PanelContainerProps) {
    return (
        <div className={getClassName(props.currentPanel, props.recentlyChanged)}>
            {props.children}
        </div>
    );
}

const
    pageAreaClass = 'page_area',
    navPanelActiveClass = 'app_nav_panel_active',
    asidesPanelActiveClass = 'asides_panel_active',
    mainPanelActiveClass = '';

function getClassName(currentPanel : ?PanelName, recentlyChanged : bool) {
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

    if(recentlyChanged) classes.push('recently_changed');

    return classes.join(' ');
}

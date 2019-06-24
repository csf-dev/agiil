//@flow
import * as React from "react";
import type { PanelName } from "./PanelName";
import { NavigationPanel, MainPanel, AsidesPanel } from './PanelName';
// $FlowFixMe
import style from './PanelChangeIndicator.module.scss';
import { MainContent } from 'components/pageLayout';

export type PanelChangeIndicatorProps = {
    currentPanel : ?PanelName,
    recentlyChanged : bool
};

export function PanelChangeIndicator(props : PanelChangeIndicatorProps) {
    return (
        <ul className={getClassName(props?.recentlyChanged)}>
            <li className={getIndicatorClassName(NavigationPanel, props?.currentPanel)}>
                <span className="screen_reader_only">Navigation panel{isActive(NavigationPanel, props?.currentPanel)? ' (active)' : ''}</span>
            </li>
            <li className={getIndicatorClassName(MainPanel, props?.currentPanel)}>
                <span className="screen_reader_only">Main panel{isActive(MainPanel, props?.currentPanel)? ' (active)' : ''}</span>
            </li>
            <li className={getIndicatorClassName(AsidesPanel, props?.currentPanel)}>
                <span className="screen_reader_only">Asides panel{isActive(AsidesPanel, props?.currentPanel)? ' (active)' : ''}</span>
            </li>
        </ul>
    );
}

function getClassName(recentlyChanged : ?bool) {
    const classes = [ style.panelChangeIndicator ];

    if(recentlyChanged)
        classes.push(style.active);

    return classes.join(' ');
}

function getIndicatorClassName(name : PanelName, currentPanel : ?PanelName) {
    const classes = [ style.panelIndicator ];

    if(isActive(name, currentPanel))
        classes.push(style.active);

    return classes.join(' ');
}

function isActive(name : PanelName, currentPanel : ?PanelName) {
    return (currentPanel === name) || (!currentPanel && name === MainPanel);
}
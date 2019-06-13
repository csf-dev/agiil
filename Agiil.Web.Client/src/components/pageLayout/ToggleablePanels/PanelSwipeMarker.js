//@flow
import * as React from "react";
import type { ActivePagePanel } from 'models/pageLayout';
import { NavigationPanel, MainPanel, AsidesPanel } from 'components/pageLayout';

export function PanelSwipeMarker(props : ActivePagePanel) {
    return (
        <ol className={getListClass(props)}>
            <li className={getClassName(props, NavigationPanel)}>
                <span className="screen_reader_only">
                    Navigation panel {getActiveText(props, NavigationPanel)}
                </span>
            </li>
            <li className={getClassName(props, MainPanel)}>
                <span className="screen_reader_only">
                    Main panel {getActiveText(props, MainPanel)}
                </span>
            </li>
            <li className={getClassName(props, AsidesPanel)}>
                <span className="screen_reader_only">
                    Properties panel {getActiveText(props, AsidesPanel)}
                </span>
            </li>
        </ol>
    );
}

function getActiveText(props : ActivePagePanel, panelName : string) : string {
    return `(${getStatus(props, panelName)})`;
}

function getClassName(props : ActivePagePanel, panelName : string) : string {
    return `${panelName} ${getStatus(props, panelName)}`;
}

function getStatus(props : ActivePagePanel, panelName : string) : string {
    return (props.activePanel === panelName)? 'active' : 'inactive';
}

function getListClass(props : ActivePagePanel) {
    const classes = ['panel_swipe_marker'];
    if(props.recentlyChanged) classes.push('recently_changed');
    return classes.join(' ');
}
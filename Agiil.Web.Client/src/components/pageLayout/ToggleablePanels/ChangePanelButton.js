//@flow
import * as React from "react";
import type { ChangePanelProps } from './ChangePanelProps';
import { Left, Right } from './ChangePanelProps'
import { NavigationPanel, MainPanel, AsidesPanel } from 'components/pageLayout';

export function ChangePanelButton(props : ChangePanelProps) {
    const title = getTitle(props);
    return (
        <button className={`change_panel ${props.type}`}
                title={title}
                onClick={() => props.onClick()}
                disabled={!props.enabled}>
            <span className="screen_reader_only">Move panels {props.type.toLowerCase()}</span>
        </button>
    );
}

function getTitle(props : ChangePanelProps) {
    if(props.type === Left)
        return getLeftTitle(props);
    return getRightTitle(props);
}

function getLeftTitle(props : ChangePanelProps) {
    switch(props.activePanel) {
    case NavigationPanel:
        return null;
    case AsidesPanel:
        return 'Close the asides panel';
    default:
        return 'Open the navigation panel';
    }
}

function getRightTitle(props : ChangePanelProps) {
    switch(props.activePanel) {
    case NavigationPanel:
        return 'Close the navigation panel';
    case AsidesPanel:
        return null;
    default:
        return 'Open the asides panel';
    }
}
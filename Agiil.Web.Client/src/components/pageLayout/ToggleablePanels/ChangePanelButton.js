//@flow
import * as React from "react";
import type { ChangePanelProps } from './ChangePanelProps';

export function ChangePanelButton(props : ChangePanelProps) {
    return (
        <button className={`change_panel ${props.type}`}
                title={`Move ${props.type.toLocaleLowerCase()}`}
                onClick={() => props.onClick()}>
            <span className="screen_reader_only">Move panels {props.type.toLocaleLowerCase()}</span>
        </button>
    );
}
//@flow
import * as React from "react";
import type { ActivePagePanel } from 'models/pageLayout';
import { NavigationPanel, MainPanel, AsidesPanel } from 'components/pageLayout';

export function CurrentPanelButton(props : ActivePagePanel) {
    return (
        <button className="active_panel_indicator">
            <span>{getPanelName(props)}</span>
        </button>
    );
}

function getPanelName(props : ActivePagePanel) : string {
    switch (props.activePanel) {
    case NavigationPanel:
        return 'Navigation';

    case AsidesPanel:
        return 'Properties';

    // Default includes MainPanel
    default:
        return 'Main';
    }
}
//@flow
import * as React from "react";
import type { ActivePagePanel } from 'models/pageLayout';
import { NavigationPanel, MainPanel, AsidesPanel } from 'components/pageLayout';
// $FlowFixMe
import styles from './CurrentPanelButton.module.scss';

export type CurrentPanelButtonProps = ActivePagePanel & {
    onClick: () => void
};

export function CurrentPanelButton(props : CurrentPanelButtonProps) {
    return (
        <button className={`${styles.activePanelIndicator} activePanel`}
                title="Active panel">
            <span className={styles.text}>{getPanelName(props)}</span>
        </button>
    );
}

function getPanelName(props : CurrentPanelButtonProps) : string {
    switch (props.activePanel) {
    case NavigationPanel:
        return 'Navigation';

    case AsidesPanel:
        return 'Asides';

    // Default includes MainPanel
    default:
        return 'Main';
    }
}
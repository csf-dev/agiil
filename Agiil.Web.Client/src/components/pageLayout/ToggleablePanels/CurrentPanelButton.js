//@flow
import * as React from "react";
import type { ActivePagePanel } from 'models/pageLayout';
import { NavigationPanel, MainPanel, AsidesPanel } from 'components/pageLayout';
// $FlowFixMe
import styles from './CurrentPanelButton.module.scss';
import { ChoosePanelModal } from './ChoosePanelModal';
import type { PanelName } from './PanelName';

export type CurrentPanelButtonProps = ActivePagePanel & {
    onClick: () => void,
    dismissModal: () => void,
    choosePanel: (panel : PanelName) => void,
};

export function CurrentPanelButton(props : CurrentPanelButtonProps) {
    return (
        <>
            <button className={`${styles.activePanelIndicator} activePanel`}
                    title="Active panel"
                    onClick={props.onClick}>
                <span className={styles.text}>{getPanelName(props)}</span>
            </button>
            <ChoosePanelModal dismissModal={props.dismissModal} choosePanel={props.choosePanel} />
        </>
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
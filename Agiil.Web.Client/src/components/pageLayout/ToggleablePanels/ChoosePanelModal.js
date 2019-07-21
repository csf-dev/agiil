//@flow
import * as React from "react";
import type { PanelName } from './PanelName';
import { NavigationPanel, MainPanel, AsidesPanel } from './PanelName';
// $FlowFixMe
import styles from './ChoosePanelModal.module.scss';
import { ModalWindow, Narrow } from 'components/modals';

export type ChoosePanelModalProps = {
    dismissModal: () => void,
    choosePanel: (panel : PanelName) => void,
};

export function ChoosePanelModal(props : ChoosePanelModalProps) {
    return (
        <ModalWindow width={Narrow}>
            <header>
                <button className={styles.cancelButton} title="Cancel" onClick={() => props.dismissModal()}>
                    <span className="screen_reader_only">Cancel</span>
                </button>
                <h2>Select panel</h2>
            </header>
            <ul className={styles.panelsList}>
                <li>
                    <button onClick={() => props.choosePanel(NavigationPanel)}>Navigation</button>
                </li>
                <li>
                    <button onClick={() => props.choosePanel(MainPanel)}>Main</button>
                </li>
                <li>
                    <button onClick={() => props.choosePanel(AsidesPanel)}>Asides</button>
                </li>
            </ul>
            <div className={`touchscreenOnly ${styles.touchscreenTip}`}>
                <h3>Tip</h3>
                <p>
                    On a touchscreen, you may swipe left/right to switch panels.
                </p>
            </div>
        </ModalWindow>
    );
}
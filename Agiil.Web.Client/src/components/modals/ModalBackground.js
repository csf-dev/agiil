//@flow
import React from 'react';
// $FlowFixMe
import styles from './ModalBackground.module.scss';
import type { HasChildren } from 'components/common';

export function ModalBackground() {
    return (
        <div className={styles.modalBackground} />
    );
}
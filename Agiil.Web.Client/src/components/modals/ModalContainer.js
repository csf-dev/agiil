//@flow
import React from 'react';
// $FlowFixMe
import styles from './ModalContainer.module.scss';
import type { HasChildren } from 'components/common';
import type { ModalWidth } from './ModalWindow';
import { Narrow, Wide } from './ModalWindow';

export type ModalContainerProps = HasChildren & {
    width : ModalWidth
};

export function ModalContainer(props : ModalContainerProps) {
    return (
        <section className={getClassName(props)}>
            {props.children}
        </section>
    );
}

function getClassName(props : ModalContainerProps) {
    const classes = [ styles.modalContainer ];

    switch(props.width) {
    case Narrow:
        classes.push(styles.narrow);
        break;

    case Wide:
        classes.push(styles.wide);
        break;

    default:
        classes.push(styles.medium);
        break;
    }

    return classes.join(' ');
}
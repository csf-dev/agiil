//@flow
// $FlowFixMe
import { styles } from './ModalWindow.module.scss';
import type { HasChildren } from 'components/common';

export type ModalWindowProps = HasChildren;

export function ModalBackground(props : ModalWindowProps) {
    return (
        <section className={styles.modalWindow}>
            {props.children}
        </section>
    );
}
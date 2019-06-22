//@flow
// $FlowFixMe
import { styles } from './ModalBackground.module.scss';
import type { HasChildren } from 'components/common';

export type ModalBackgroundProps = HasChildren & {
    visible : bool
};

export function ModalBackground(props : ModalBackgroundProps) {
    if(!props.visible) return null;

    return (
        <div className={styles.modalBackground}>
            {props.children}
        </div>
    );
}
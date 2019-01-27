//@flow
import React from "react";
import type { SelectableLabel } from '../../../domain/Labels/Label';
// $FlowFixMe
import styles from './LabelChooser.scss';

type Props = {
    label : SelectableLabel,
    onRemove : () => void
};

export default function SelectedLabel(props : Props) {
    const
        itemClasses = props.label.selected? (styles.forRemoval || 'forRemoval') : null,
        messagesString = `Label '${props.label.name}'`;
    
    return (
        <li className={itemClasses} title={messagesString}>
            {props.label.name}
            <button className={styles.removeLabel || 'removeLabel'} title="Remove" onClick={props.onRemove}>❌</button>
        </li>
    );
}
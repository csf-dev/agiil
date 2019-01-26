//@flow
import React from "react";
import type { SelectableLabel } from '../../../domain/Labels/Label';

type Props = {
    label : SelectableLabel,
    onRemove : () => void
};

export default function SelectedLabel(props : Props) {
    const
        itemClasses = props.label.selected? 'for-removal' : '',
        messagesString = `Label '${props.label.name}'`;
    
    return (
        <li className={itemClasses} title={messagesString}>
            {props.label.name}
            <button className="remove-label" title="Remove" onClick={props.onRemove}>❌</button>
        </li>
    );
}
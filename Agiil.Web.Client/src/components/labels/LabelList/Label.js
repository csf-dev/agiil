//@flow
import * as React from "react";
import type { SelectableLabel } from 'models/labels';
// $FlowFixMe
import styles from './labelList.module.scss';

export type TitleFormatter = (label : SelectableLabel) => string;

export type LabelProps = {
    label : SelectableLabel,
    titleFormatter? : TitleFormatter,
    title?: string,
    children : React.Node
}

export function Label(props : LabelProps) {
    const itemClass = getLabelClasses(props);
    let title = getTitle(props);
    
    return (
        <li className={itemClass} title={title}>
            {props.children}
        </li>
    );
}

function getLabelClasses(props : LabelProps) : ?string {
    if(props.label.selected)
        return (styles.selected);
    return null;
}

function getTitle(props : LabelProps) : ?string {
    if(props.title) return props.title;
    else if(props.titleFormatter) return props.titleFormatter(props.label);
    return null;
}
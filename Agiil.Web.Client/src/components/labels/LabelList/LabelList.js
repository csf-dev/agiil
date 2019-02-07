//@flow
import * as React from "react";
// $FlowFixMe
import styles from './labelList.scss';

export type LabelListProps = {
    children : React.Node
};

export function LabelList(props : LabelListProps) {
    const listClass = styles.labelList || 'labelList';

    return (<ul className={listClass}>
        {props.children}
    </ul>);
}
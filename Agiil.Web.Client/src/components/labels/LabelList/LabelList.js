//@flow
import * as React from "react";
// $FlowFixMe
import styles from './labelList.module.scss';

export type LabelListProps = {
    children : React.Node
};

export function LabelList(props : LabelListProps) {
    return (<ul className={`${styles.labelList} LabelList`}>
        {props.children}
    </ul>);
}
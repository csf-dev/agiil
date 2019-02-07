//@flow
import * as React from "react";
// $FlowFixMe
import styles from './suggestionsList.scss';

export type SuggestionProps = {
    selected : bool,
    onChoose : () => void,
    children : React.Node
};

export function Suggestion(props : SuggestionProps) {
    return (
        <li className={getClassName(props)} onClick={props.onChoose}>
            {props.children}
        </li>
    );
}

function getClassName(props : SuggestionProps) {
    const classes = [ styles.suggestion ];
    if(props.selected) classes.push(styles.selected);
    return classes.join(' ');
}
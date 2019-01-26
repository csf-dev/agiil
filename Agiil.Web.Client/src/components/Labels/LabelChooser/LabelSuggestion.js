//@flow
import * as React from "react";
import type { SelectableLabel } from '../../../domain/Labels/Label';
// $FlowFixMe
import styles from './LabelChooser.scss';

type Props = {
    label: SelectableLabel,
    clickable: bool,
    onClick: (label: SelectableLabel) => void
};

export default function LabelSuggestion(props : Props) {
    return (
        <li className={getClassNames(props.label).join(' ')} onClick={getClickHandler(props)}>
            <strong>{props.label.name}</strong>
            {getOpenCount(props.label)}
            {getClosedCount(props.label)}
        </li>
    );
}

function getClassNames(props : SelectableLabel) {
    const classNames = [styles.LabelSuggestion];
    if(props.selected) classNames.push(styles.selected);
    return classNames;
}

function getTicketOrTickets(count : number) {
    if(count == 1) return 'ticket';
    return 'tickets';
}

function getOpenCount(label : SelectableLabel) {
    const count = label.openTickets;
    if(typeof count !== 'number') return null;
    return <span className="open-count">{count} open {getTicketOrTickets(count)}</span>
}

function getClosedCount(label : SelectableLabel) {
    const count = label.closedTickets;
    if(typeof count !== 'number') return null;
    return <span className="closed-count">{count} closed {getTicketOrTickets(count)}</span>
}

function getClickHandler(props : Props) {
    return (ev : SyntheticEvent<HTMLLIElement>) => {
        if(!props.clickable) return;
        props.onClick(props.label);
    }
}
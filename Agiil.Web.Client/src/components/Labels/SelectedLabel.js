//@flow
import React from "react";
import type { RemovableLabel } from '../../models/Labels/Label';

type Props = {
    label : RemovableLabel,
    onRemove : () => void
};

function ticketOrTickets(count : number) {
    return (count == 1)? 'ticket' : 'tickets';
}

function getOpenMessage(count : number | void) : string | null {
    if(count === undefined) return null;
    return `${count} open ${ticketOrTickets(count)}`
}

function getClosedMessage(count : number | void) : string | null {
    if(count === undefined) return null;
    return `${count} closed ${ticketOrTickets(count)}`
}

export default function SelectedLabel(props : Props) {
    const
        openCount = props.label.openTickets,
        closedCount = props.label.closedTickets,
        itemClasses = props.label.selectedForRemoval? 'for-removal' : '',
        messages = [ getOpenMessage(openCount), getClosedMessage(closedCount) ],
        messagesString = messages.filter(x => x).join(', ');
    
    return (
        <li className={itemClasses} title={messagesString}>
            {props.label.name}
            <button className="remove-label" title="Remove" onClick={props.onRemove}>❌</button>
        </li>
    );
}
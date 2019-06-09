//@flow
import * as React from "react";
import type { ViewTicketProps } from 'components/viewTicket';
import { AsideItem } from 'components/pageLayout';

export function TicketLabels(props : ViewTicketProps) {
    return (
        <AsideItem>
            <h3>Labels</h3>
            {getLabelsList(props)}
        </AsideItem>
    );
}

function getLabelsList(props : ViewTicketProps) {
    if(!props.ticket.hasLabels)
        return (<p>This ticket has no labels</p>);

    return (<ul className="ticket_labels">{props.ticket.labels.map(labelMapper)}</ul>);
}

function labelMapper(label : string, idx : number) {
    return (
        <li key={idx}>
            <a href={getLabelUrl(label)}><span className="name">{label}</span></a>
        </li>
    );
}

function getLabelUrl(label : string) {
    const encodedName = encodeURIComponent(label);
    return `Label/Index/${encodedName}`;
}
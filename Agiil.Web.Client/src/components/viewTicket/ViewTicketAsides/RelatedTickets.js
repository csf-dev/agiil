//@flow
import * as React from "react";
import type { ViewTicketProps } from 'components/viewTicket';
import { AsideItem } from 'components/pageLayout';
import type { TicketRelationship } from 'models/tickets/TicketRelationship';

export function RelatedTickets(props : ViewTicketProps) {
    return (
        <AsideItem>
            <h3>Related tickets</h3>
        </AsideItem>
    );
}

function getRelatedTicketsContent(props : ViewTicketProps) {
    if(!props.ticket.hasRelationships)
        return (<p>No related tickets</p>);

    return (<ul className="related_tickets">{props.ticket.relationships.map(relatedTicketMapper)}</ul>);
}

function relatedTicketMapper(relationship : TicketRelationship, idx : number) {
    return (
        <li key={idx}>
            <header>
                <span className="relationship_summary">{relationship.summary}</span>
            </header>
            <div>
                <a href={relationship.ticket.viewUrl}
                   className="ticket_title">
                    {relationship.ticket.title}
                </a>
                <a href={relationship.ticket.viewUrl}
                   className="ticket_reference">
                    {relationship.ticket.ticketReference.toString()}
                </a>
            </div>
        </li>
    );
}

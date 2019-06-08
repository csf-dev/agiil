//@flow
import * as React from "react";
import TicketDetail from 'models/tickets/TicketDetail';
import { MainContentAsides } from 'components/pageLayout';
import type { ViewTicketProps } from 'components/viewTicket';

export function ViewTicketAsides(props : ViewTicketProps) {
    return (
        <MainContentAsides>
            <header><h2>Ticket properties</h2></header>
            <TicketStatus ticket={props.ticket} />
            <EditTicketLink ticket={props.ticket} />
            <TicketSprint ticket={props.ticket} />
            <TicketLabels ticket={props.ticket} />
            <TicketStoryPoints ticket={props.ticket} />
            <TicketWorkLog ticket={props.ticket} />
            <RelatedTickets ticket={props.ticket} />
            <TicketCreationInfo ticket={props.ticket} />
        </MainContentAsides>
    );
}
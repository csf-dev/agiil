//@flow
import TicketDetail from 'models/tickets/TicketDetail';
import TicketComment from 'models/tickets/TicketComment';
import type { TicketReference } from 'models/tickets/TicketReference';

export interface GetsTicketDetail {
    getTicketDetail() : TicketDetail;
}

export interface GetsTicketComments {
    getTicketComments(reference : TicketReference) : Array<TicketComment>;
}
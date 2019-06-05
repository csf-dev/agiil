//@flow
import TicketSummary from './TicketSummary';

export type TicketRelationship = {
    id : number,
    relationshipId : number,
    summary: string,
    ticket : TicketSummary
};
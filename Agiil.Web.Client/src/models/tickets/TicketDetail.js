//@flow
import TicketComment from './TicketComment';
import type { TicketReference } from './TicketReference';

export default class TicketDetail {
    id : number;
    title : string;
    type : string;
    reference : string;
    descriptionMarkup : string;
    comments : Array<TicketComment>;

    getTicketReference() : TicketReference {
        return { reference : this.reference };
    }
}
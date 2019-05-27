//@flow
import TicketComment from './TicketComment';
import type { TicketReference } from './TicketReference';
import type { FeedbackMessage } from 'models/common/FeedbackMessage'

export default class TicketDetail {
    id : number;
    title : string;
    type : string;
    reference : string;
    descriptionMarkup : string;
    comments : Array<TicketComment>;
    newCommentFeedback : ?FeedbackMessage;

    getTicketReference() : TicketReference {
        return { reference : this.reference };
    }
}
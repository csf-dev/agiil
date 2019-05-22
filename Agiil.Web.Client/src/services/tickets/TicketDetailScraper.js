//@flow
import { GetsTicketDetail, GetsTicketComments } from './GetsTicketDetail';
import TicketDetail from 'models/tickets/TicketDetail';
import { querySelectorMandatory } from 'util/dom';
import getTicketCommentsProvider from './TicketCommentsScraper';

const
    idQuery = '.content_container form.open_close_ticket',
    titleQuery = '.content_area > header h1',
    typeQuery = '.content_area > header .ticket_identity .ticket_type',
    referenceQuery = '.content_area > header .ticket_identity .ticket_reference',
    descriptionMarkupQuery = '.main_content .ticket_description .description_content';

export class TicketDetailScraper implements GetsTicketDetail {
    #commentsProvider : GetsTicketComments;

    getTicketDetail() : TicketDetail {
        const result = new TicketDetail();
        const commentsProvider = this.#commentsProvider;

        result.id = getTicketId();
        result.type = querySelectorMandatory(typeQuery).innerText || '';
        result.reference = getTicketReference();
        result.title = querySelectorMandatory(titleQuery).innerText || '';
        result.descriptionMarkup = getTicketDescriptionMarkup();
        result.comments = commentsProvider.getTicketComments(result.getTicketReference());

        return result;
    };

    constructor(commentsProvider : GetsTicketComments) {
        this.#commentsProvider = commentsProvider;
    }
}

export default function getTicketDetailProvider() : GetsTicketDetail {
    const commentsProvider = getTicketCommentsProvider();
    return new TicketDetailScraper(commentsProvider);
}

function getTicketId() : number {
    const
        idElement = querySelectorMandatory(idQuery),
        actionAttribute = idElement.getAttribute('action') || '',
        expectedActionPattern = /\w+\/\w+\/(\d+)/,
        idMatch = actionAttribute.match(expectedActionPattern),
        idCaptures = [...(idMatch || [])];

    if(idCaptures.length == 2)
        return parseInt(idCaptures[1]);
    return 0;
}

function getTicketReference() : string {
    const
        referenceText = querySelectorMandatory(referenceQuery).innerText || '',
        expectedReferencePattern = /#(\w+)/,
        referenceMatch = referenceText.match(expectedReferencePattern),
        referenceCaptures = [...(referenceMatch || [])];

    if(referenceCaptures.length == 2)
        return referenceCaptures[1];

    return '';
}

function getTicketDescriptionMarkup() {
    return querySelectorMandatory(descriptionMarkupQuery).innerHTML;
}

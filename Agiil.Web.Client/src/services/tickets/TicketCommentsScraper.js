//@flow
import { GetsTicketComments } from './GetsTicketDetail';
import TicketComment from 'models/tickets/TicketComment';
import type { TicketReference } from 'models/tickets/TicketReference';
import { querySelectorMandatory } from 'util/dom';

const
    commentsQuery = '.main_content .ticket_comments .comment_list > li';

export class TicketCommentsScraper implements GetsTicketComments {
    getTicketComments(reference : TicketReference) : Array<TicketComment> {
        return [...document.querySelectorAll(commentsQuery)]
            .map(getComment);
    }
}

export default function getTicketCommentsProvider() : GetsTicketComments {
    return new TicketCommentsScraper();
}

function getComment(commentElement : HTMLElement) : TicketComment {
    const result = new TicketComment();

    result.id = getCommentId(commentElement);
    result.author = querySelectorMandatory('.author_name', commentElement).innerText || '';
    result.createdTimestamp = querySelectorMandatory('.author_timestamp', commentElement).innerText || '';
    result.commentMarkup = getCommentMarkup(commentElement);

    return result;
}

function getCommentId(commentElement : HTMLElement) : number {
    const idElement = commentElement.querySelector('a.edit_comment');
    if(!idElement) return 0;

    const
        idPattern = /\w+\/\w+\/(\d+)/,
        idMatch = [...((idElement.getAttribute('href') || '').match(idPattern) || [])];
    
    if(idMatch.length == 2)
        return parseInt(idMatch[1]);
    return 0;
}

function getCommentMarkup(commentElement : HTMLElement) : string {
    return querySelectorMandatory('.comment_content', commentElement).innerHTML;
}
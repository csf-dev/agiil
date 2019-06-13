//@flow
import { GetsTicketDetail } from './GetsTicketDetail';
import TicketComment from 'models/tickets/TicketComment';
import type { TicketRelationship } from 'models/tickets/TicketRelationship';
import TicketDetail from 'models/tickets/TicketDetail';
import { parseTimespan } from 'util/parseTimespan';
import TicketSummary from 'models/tickets/TicketSummary';

export class TicketDetailFromServerStateProvider implements GetsTicketDetail {
    #state : any;

    getTicketDetail() : ?TicketDetail {
        const state = this.#state;
        if(!state || !state.Id || !state.Reference || !state.Type?.Name) return null;

        const output = new TicketDetail(state.Id, state.Reference, state.Type.Name);

        output.title = state.Title || '';
        output.descriptionMarkup = state.HtmlDescription || '';
        output.author = state.Creator || '';
        output.created = state.Created || '';
            //$FlowFixMe
        output.labels = state.Labels?.map(x => x.Name) || [];
            //$FlowFixMe
        output.sprint = { id: state.Sprint?.Id, name: state.Sprint?.Name } || null;
            //$FlowFixMe
        output.relationships = state.Relationships?.map(relationshipMapper).filter(x => x) || [];
            //$FlowFixMe
        output.comments = state.Comments?.map(commentMapper).filter(x => x) || [];
        output.isOpen = state.Closed !== true;
        output.storyPoints = state.StoryPoints || null;
        output.workLoggedMinutes = parseTimespan(state.TotalWorkLogged)?.totalMinutes || 0;

        return output;
    }

    constructor(state : any) {
        this.#state = state;
    }
}

function relationshipMapper(relationship : any) : ?TicketRelationship {
    if(!relationship) return null;

    return {
        id: relationship.Id?.Value,
        relationshipId : relationship.RelationshipId?.Value,
        summary: relationship.Summary,
        ticket: getTicketSummary(relationship.RelatedTicket)
    };
}

function commentMapper(comment : any) : ?TicketComment {
    const output = new TicketComment(comment.Id || 0);
    output.author = comment.Author || '';
    output.createdTimestamp = comment.Timestamp || '';
    output.commentMarkup = comment.HtmlBody || '';

    return output;
}

function getTicketSummary(relatedTicket : any) : TicketSummary {
    const output = new TicketSummary(relatedTicket.Id, relatedTicket.Reference, relatedTicket.TypeName);

    output.title = relatedTicket.Title || '';
    output.isOpen = relatedTicket.Closed !== true;
    output.storyPoints = relatedTicket.StoryPoints || null;
    output.created = relatedTicket.Created || '';
    output.author = relatedTicket.Creator || '';
    output.humanReadableCreated = relatedTicket.ShortTimestamp || null;

    return output;
}

export default function getTicketDetailProvider(state : any) : GetsTicketDetail {
    return new TicketDetailFromServerStateProvider(state || window.ticketData);
}
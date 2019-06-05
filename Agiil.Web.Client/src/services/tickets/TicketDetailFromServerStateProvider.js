//@flow
import { GetsTicketDetail } from './GetsTicketDetail';
import type { TicketComment } from 'models/tickets/TicketComment';
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
        output.labels = state.Labels?.map(x => x.Name) || [];
        output.sprint = { id: state.Sprint?.Id, name: state.Sprint?.Name } || null;
        output.relationships = state.Relationships?.map(relationshipMapper).filter(x => x) || [];
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
    return {
        id: comment.Id || 0,
        author: comment.Author || '',
        createdTimestamp: comment.Timestamp || '',
        commentMarkup: comment.HtmlBody || ''
    };
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

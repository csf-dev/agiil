//@flow
import type { TicketComment } from './TicketComment';
import type { FeedbackMessage } from 'models/common/FeedbackMessage';
import type { Sprint } from 'models/sprints/Sprint';
import type { TicketRelationship } from './TicketRelationship';
import TicketSummary from './TicketSummary';

export default class TicketDetail extends TicketSummary {
    
    descriptionMarkup : string;
    comments : Array<TicketComment>;
    labels : Array<string>;
    relationships : Array<TicketRelationship>;
    sprint : ?Sprint;
    workLoggedMinutes : number;

    get hasWorkLogged() { return this.workLoggedMinutes > 0; }
    get hasRelationships() { return this.relationships && this.relationships.length >= 1; }
    get hasLabels() { return this.labels && this.labels.length >= 1; }

    constructor(id : number, reference : string, type : string) {
        super(id, reference, type);

        this.title = '';
        this.descriptionMarkup = '';
        this.comments = [];
        this.labels = [];
        this.isOpen = true;
        this.relationships = [];
        this.author = '';
        this.created = '';
        this.workLoggedMinutes = 0;
    }
}
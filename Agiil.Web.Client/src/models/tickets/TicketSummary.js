//@flow
import { TicketReference } from './TicketReference';

export default class TicketSummary {
    #id : number;
    #reference : string;
    #type : string;
    #humanReadableCreated : ?string;

    title : string;
    isOpen : bool;
    storyPoints : ?number;
    created : string;
    author : string;

    get id() { return this.#id; }
    get reference() { return this.#reference; }
    get type() { return this.#type; }
    get isClosed() { return !this.isOpen; }
    get editUrl() { return `Ticket/Edit/${this.#reference}`; }
    get viewUrl() { return `Ticket/Index/${this.#reference}`; }
    get ticketReference() { return new TicketReference(this.reference); }
    get hasStoryPoints() { return !!this.storyPoints; }
    get humanReadableCreated() { return this.#humanReadableCreated || this.created; };
    set humanReadableCreated(val : ?string) { this.#humanReadableCreated = val; }


    constructor(id : number, reference : string, type : string) {
        this.#id  = id;
        this.#reference = reference;
        this.#type = type;
    }
}
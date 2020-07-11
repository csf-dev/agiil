//@flow

export default class TicketComment {

    #id : number;

    get id() { return this.#id; }
    author : ?string;
    createdTimestamp : ?string;
    commentMarkup : ?string;
    canEdit : bool;
    canDelete : bool;

    get editUrl() { return `Comment/Edit/${this.id}`; }

    constructor(id : number) {
        this.#id = id;
    }
}
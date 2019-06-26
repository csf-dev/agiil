//@flow

export class TicketReference {
    #reference : string;

    get reference() { return this.#reference; }

    toString() { return `#${this.reference}`; }

    constructor(reference : string) {
        this.#reference = reference;
    }
}
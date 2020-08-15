//@flow
import type { InteractionsWithElement, Coordinate, GetsInteractions } from 'services/domEvents';
import { merge } from 'rxjs'; 

export class IncludeMouseMovementsDecorator implements GetsInteractions {
    #wrapped : GetsInteractions;
    #mouseInteractionsProvider : GetsInteractions;

    getInteractions(): InteractionsWithElement {
        const
            wrappedInteractions = this.#wrapped.getInteractions(),
            mouseInteractions = this.#mouseInteractionsProvider.getInteractions();

        return {
            start: merge(wrappedInteractions.start, mouseInteractions.start),
            move: merge(wrappedInteractions.move, mouseInteractions.move),
            end: merge(wrappedInteractions.end, mouseInteractions.end)
        };
    }

    constructor(wrapped : GetsInteractions, mouseInteractionsProvider : GetsInteractions) {
        this.#wrapped = wrapped;
        this.#mouseInteractionsProvider = mouseInteractionsProvider;
    }
}
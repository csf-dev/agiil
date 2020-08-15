//@flow
import type { Observable } from 'rxjs';
import type { Swipe } from './Swipe';
import type { GetsSwipes } from './GetsSwipes';
import type { GetsSwipeEvents } from './GetsSwipeEvents';
import { map } from 'rxjs/operators';
import type { SwipeEventToSwipeMapper } from './SwipeEventToSwipeMapper';

export class SwipeProvider implements GetsSwipes {
    #eventProvider : GetsSwipeEvents;
    #mappingFunc : SwipeEventToSwipeMapper;

    getSwipes() : Observable<Swipe> {
        return this.#eventProvider.getEvents()
            .pipe(map(this.#mappingFunc));
    }

    constructor(eventProvider : GetsSwipeEvents,
                mappingFunc : SwipeEventToSwipeMapper) {
        this.#eventProvider = eventProvider;
        this.#mappingFunc = mappingFunc;
    }
}

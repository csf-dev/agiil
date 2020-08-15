//@flow
import type { ScrollFrame } from './ScrollFrame';
import type { Observable } from 'rxjs';
import { map, filter, throttleTime } from 'rxjs/operators';
import type { GetsScrollFrames} from './GetsScrollFrames';

export class ScrollFrameProvider implements GetsScrollFrames {
    #observable : Observable<Event>;
    #frameDuration : number;

    getScrollFrames() : Observable<ScrollFrame> {
        return this.#observable.pipe(
            throttleTime(this.#frameDuration),
            map(mapToScrollEvent),
            filter(x => !!x)
        );
    }

    constructor(observable : Observable<Event>, frameDuration : number) {
        this.#observable = observable;
        this.#frameDuration = frameDuration;
    }
}


function mapToScrollEvent(event : Event) : ?ScrollFrame {
    if(!(event.target instanceof HTMLElement)) return null;

    const scrolledElement = event.target;
    return {
        scrolledElement,
        coords: {
            x: scrolledElement.scrollLeft,
            y: scrolledElement.scrollTop,
        },
    };
}
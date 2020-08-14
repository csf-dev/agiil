//@flow
import { fromEvent } from 'rxjs';
import type { Observable } from 'rxjs';
import { map, filter } from 'rxjs/operators';
import { modernizr, tests } from 'util/modernizr';

export type ScrollEvent = {
    scrolledElement : HTMLElement,
    xPosition : number,
    yPosition : number
};

export function getScrolls(element : HTMLElement) : Observable<ScrollEvent> {
    return fromEvent(element, 'scroll', (getScrollOptions(true) : any))
        .pipe(map<Event,?ScrollEvent>(mapToScrollEvent), filter(x => !!x));
}

export function getElementScrolls(element : HTMLElement) : Observable<ScrollEvent> {
    return fromEvent(element, 'scroll', (getScrollOptions(false) : any))
        .pipe(map<Event,?ScrollEvent>(mapToScrollEvent), filter(x => !!x));
}

/**
 * Gets the 'options' parameter to `fromEvent` in a cross-browser fashion.
 * See https://developer.mozilla.org/en-US/docs/Web/API/EventTarget/addEventListener#Usage_notes
 */
function getScrollOptions(includeChilden : boolean) : EventListenerOptionsOrUseCapture {
    if(!modernizr.has(tests.passiveeventlisteners))
        return includeChilden;

    return {
        capture: includeChilden,
        passive: true
    };
}

function mapToScrollEvent(event : Event) : ?ScrollEvent {
    if(!(event.target instanceof HTMLElement))
        return null;

    const scrolledElement = event.target;
    return {
        scrolledElement,
        xPosition: scrolledElement.scrollLeft,
        yPosition: scrolledElement.scrollTop,
    };
}
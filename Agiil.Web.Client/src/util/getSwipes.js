//@flow
import type { Observable } from 'rxjs';
import { interval } from 'rxjs'; 
import { map, takeLast, concatMap, takeUntil, withLatestFrom, scan, startWith } from 'rxjs/operators';
import getTouchEvents from './getTouchEvents';
import type { Coordinate, TouchEventsForElement } from './getTouchEvents';
import { getScrolls } from './getScrolls';
import type { ScrollEvent } from './getScrolls';

export type SwipeEvent = {
    startPosition : Coordinate,
    endPosition : Coordinate,
    durationMs : number,
    vector : Coordinate,
    velocity : number,
};

export type SwipeEventWithInnerScrolls = SwipeEvent & {
    innerScrolls : InnerScrollEvents,
};

export type CumulativeScrollInfo = {
    scrolledElement: HTMLElement,
    xOrigin: number,
    xOffset: number,
    yOrigin: number,
    yOffset: number,
};

export type InnerScrollEvents = {
    scrolledElements : Map<HTMLElement, CumulativeScrollInfo>
};

export type SwipeOptions = {
    allowMouseSwipes? : boolean,
    includeInnerElementScrolling? : boolean,
};

const defaultSwipeOptions : SwipeOptions = {
    allowMouseSwipes: false,
    includeInnerElementScrolling: false,
};

function getSwipeOptions(options : ?SwipeOptions) {
    return { ...defaultSwipeOptions, ...(options || {}) };
}

export default function getSwipes(element : HTMLElement, options : ?SwipeOptions = null) : Observable<SwipeEvent> {
    const
        resolvedOptions = getSwipeOptions(options),
        events = getTouchEvents(element, resolvedOptions.allowMouseSwipes);

    return events.start.pipe(concatMap(getTimedSwipeEndingFactory(events, element)), map(getSwipeEventMapper(resolvedOptions)));
}

function getSwipeEventMapper(options : SwipeOptions) : (ev : SwipeEventWithInnerScrolls) => SwipeEvent {
    return ev => {
        const swipeEvent = {
            startPosition: ev.startPosition,
            endPosition: ev.endPosition,
            durationMs: ev.durationMs,
            vector: ev.vector,
            velocity: ev.velocity
        };

        if(options.includeInnerElementScrolling) return swipeEvent;

        // Subtract any scrolling from the swipe vector.
        // This means that the distance scrolled won't count towards the vector or
        // the velocity of the swipe.
        // 
        // This is actually handled as addition, because the scroll offset will be
        // in the opposite direction to the swipe, so adding them will always tend
        // towards zero.
        ev.innerScrolls.scrolledElements.forEach(scrollInfo => {
            swipeEvent.vector.x += scrollInfo.xOffset;
            swipeEvent.vector.y += scrollInfo.yOffset;
        });

        // We must recalculate the velocity at this point
        const
            xVelocity = swipeEvent.vector.x / swipeEvent.durationMs,
            yVelocity = swipeEvent.vector.y / swipeEvent.durationMs,
            velocity = Math.sqrt(Math.pow(xVelocity, 2) + Math.pow(yVelocity, 2));
        swipeEvent.velocity = velocity;
        
        return swipeEvent;
    };
}

function getTimedSwipeEndingFactory(events : TouchEventsForElement, element : HTMLElement) {
    return function getTimedSwipeEnding(startCoords : Coordinate) : Observable<SwipeEventWithInnerScrolls> {
        const
            timerGranularityMs = 20,
            timer = interval(timerGranularityMs);

        return timer.pipe(
            map(t =>({start: startCoords, time: t * timerGranularityMs})),
            withLatestFrom(events.move, getInnerScrolls(element)),
            takeUntil(events.end),
            takeLast(1),
            map(mapToSwipe)
        );
    }
}

function getInnerScrolls(element : HTMLElement) : Observable<InnerScrollEvents> {
    const seed : InnerScrollEvents = { scrolledElements: new Map() };
    return getScrolls(element).pipe(scan(reduceScrolls, seed), startWith({ ...seed }));
}

function reduceScrolls(acc : InnerScrollEvents, next : ScrollEvent) : InnerScrollEvents {
    const
        element = next.scrolledElement,
        cumulativeInfo = getCumulativeScrollInfo(acc.scrolledElements, element);
    cumulativeInfo.xOffset = element.scrollLeft - cumulativeInfo.xOrigin;
    cumulativeInfo.yOffset = element.scrollTop - cumulativeInfo.yOrigin;
    return { ...acc };
}

function getCumulativeScrollInfo(map : Map<HTMLElement, CumulativeScrollInfo>, element : HTMLElement) : CumulativeScrollInfo {
    if(map.has(element)) {
        // It's not null or undefined, because we just checked it exists!
        //$FlowFixMe
        return map.get(element);
    }

    const newElementInfo = {
        scrolledElement: element,
        xOrigin: element.scrollLeft,
        yOrigin: element.scrollTop,
        xOffset: 0,
        yOffset: 0,
    };
    map.set(element, newElementInfo);
    return newElementInfo;
}

type SwipeData = [{| start: Coordinate, time: number |}, Coordinate, InnerScrollEvents];

function mapToSwipe(swipeData : SwipeData) : SwipeEventWithInnerScrolls {
    const
        startPosition = swipeData[0].start,
        endPosition = swipeData[1],
        durationMs = swipeData[0].time,
        innerScrolls = swipeData[2];

    const vector = {
        x: endPosition.x - startPosition.x,
        y: endPosition.y - startPosition.y
    };

    const
        xVelocity = vector.x / durationMs,
        yVelocity = vector.y / durationMs,
        velocity = Math.sqrt(Math.pow(xVelocity, 2) + Math.pow(yVelocity, 2));

    return { startPosition, endPosition, durationMs, vector, velocity, innerScrolls };
}
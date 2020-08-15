//@flow
import type { Observable } from 'rxjs';
import { interval } from 'rxjs';
import { map, concatMap, takeLast, takeUntil, withLatestFrom } from 'rxjs/operators';
import type { SwipeEvent } from './SwipeEvent';
import type { GetsSwipeEvents } from './GetsSwipeEvents';
import type { GetsInteractions, InteractionsWithElement, Coordinate } from 'services/domEvents';
import type { GetsThrottlingInfo } from 'services/domEvents';
import type { SwipeOptions } from './SwipeOptions';
import type { GetsScrolling, ElementScrollInfoMap } from 'services/domEvents/scrolling';

export class SwipeEventProvider implements GetsSwipeEvents {
    #interactionProvider : GetsInteractions;
    #scrollProvider : GetsScrolling;
    #throttlingInfo : GetsThrottlingInfo;

    getEvents() : Observable<SwipeEvent> {
        const touchEvents = this.#interactionProvider.getInteractions();

        return touchEvents.start.pipe(
            concatMap(getTimedSwipeEndingFactory(touchEvents,
                                                 this.#scrollProvider,
                                                 this.#throttlingInfo))
        );
    }

    constructor(interactionProvider : GetsInteractions,
                scrollProvider : GetsScrolling,
                throttlingInfo : GetsThrottlingInfo) {
        this.#interactionProvider = interactionProvider;
        this.#scrollProvider = scrollProvider;
        this.#throttlingInfo = throttlingInfo;
    }
}

function getTimedSwipeEndingFactory(events : InteractionsWithElement,
                                    scrollProvider : GetsScrolling,
                                    throttlingInfo : GetsThrottlingInfo) {
    return function getTimedSwipeEnding(startCoords : Coordinate) : Observable<SwipeEvent> {
        const scrolling = scrollProvider.getScrolling();

        return throttlingInfo.framesInterval.pipe(
            map(t =>({start: startCoords, time: t * throttlingInfo.frameDurationMs})),
            withLatestFrom(events.move, scrolling),
            takeUntil(events.end),
            takeLast(1),
            map(mapToSwipeEvent)
        );
    }
}

type SwipeData = [ {| start: Coordinate, time: number |}, Coordinate, ElementScrollInfoMap ];

function mapToSwipeEvent(swipeData : SwipeData) : SwipeEvent {
    const
        startPosition = swipeData[0].start,
        endPosition = swipeData[1],
        durationMs = swipeData[0].time,
        scrollData = swipeData[2];

    return {
        positions: {
            start: { x: startPosition.x, y: startPosition.y },
            end: { x: endPosition.x, y: endPosition.y },
        },
        durationMs,
        scrolledChildElements: scrollData,
    };
}
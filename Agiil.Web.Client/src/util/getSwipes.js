//@flow
import type { Observable } from 'rxjs';
import { interval } from 'rxjs'; 
import { map, takeLast, concatMap, takeUntil, withLatestFrom } from 'rxjs/operators';
import getTouchEvents from './getTouchEvents';
import type { Coordinate } from './getTouchEvents';

export type SwipeEvent = {
    startPosition : Coordinate,
    endPosition : Coordinate,
    durationMs : number,
    vector : Coordinate,
    velocity : number
};

export default function getSwipes(element : HTMLElement, allowMouseSwipes : bool = false) : Observable<SwipeEvent> {
    const events = getTouchEvents(element, allowMouseSwipes);
    return events.start.pipe(concatMap(getTimedSwipeEnding));
}

function getTimedSwipeEnding(startCoords : Coordinate) {
    const timerGranularityMs = 20;
    const timer = interval(timerGranularityMs);

    return timer.pipe(
        map(t =>({start: startCoords, time: t * timerGranularityMs})),
        withLatestFrom(events.move),
        takeUntil(events.end),
        takeLast(1),
        map(mapToSwipe)
    );
}

type SwipeData = [{| start: Coordinate, time: number |}, Coordinate];

function mapToSwipe(swipeData : SwipeData) : SwipeEvent {
    const
        startPosition = swipeData[0].start,
        endPosition = swipeData[1],
        durationMs = swipeData[0].time;

    const vector = {
        x: endPosition.x - startPosition.x,
        y: endPosition.y - startPosition.y
    };

    const
        xVelocity = vector.x / swipe.time,
        yVelocity = vector.y / swipe.time,
        velocity = Math.sqrt(Math.pow(xVelocity, 2) + Math.pow(yVelocity, 2));

    return { startPosition, endPosition, durationMs, vector, velocity };
}
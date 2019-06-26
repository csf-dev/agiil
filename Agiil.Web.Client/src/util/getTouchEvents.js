//@flow
import type { Observable } from 'rxjs';
import { fromEvent, merge } from 'rxjs'; 
import { map } from 'rxjs/operators';

export type Coordinate = { x: number, y: number };

export type TouchEventsForElement = {
    start: Observable<Coordinate>,
    move: Observable<Coordinate>,
    end: Observable<Coordinate>,
};

export default function getTouchEvents(element : HTMLElement, allowMouseEventsAlso : bool = true) : TouchEventsForElement {
    const touchstart : Observable<Coordinate> = fromEvent(element, 'touchstart')
        .pipe(map((ev : TouchEvent) => ({ x: ev.changedTouches[0].clientX, y: ev.changedTouches[0].clientY})));
    const touchmove : Observable<Coordinate> = fromEvent(window, 'touchmove')
        .pipe(map((ev : TouchEvent) => ({ x: ev.changedTouches[0].clientX, y: ev.changedTouches[0].clientY})));
    const touchend : Observable<Coordinate> = fromEvent(window, 'touchend')
        .pipe(map((ev : TouchEvent) => ({ x: ev.changedTouches[0].clientX, y: ev.changedTouches[0].clientY})));

    if(!allowMouseEventsAlso)
    {
        return {
            start: touchstart,
            move: touchmove,
            end: touchend,
        };
    }

    const mousedown : Observable<Coordinate> = fromEvent(element, 'mousedown')
        .pipe(map((ev : MouseEvent) => ({ x: ev.clientX, y: ev.clientY})));
    const mousemove : Observable<Coordinate> = fromEvent(window, 'mousemove')
        .pipe(map((ev : MouseEvent) => ({ x: ev.clientX, y: ev.clientY})));
    const mouseup : Observable<Coordinate> = fromEvent(window, 'mouseup')
        .pipe(map((ev : MouseEvent) => ({ x: ev.clientX, y: ev.clientY})));

    return {
        start: merge(touchstart, mousedown),
        move: merge(touchmove, mousemove),
        end: merge(touchend, mouseup)
    };
}

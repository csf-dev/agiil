//@flow
import type { InteractionsWithElement, Coordinate, GetsInteractions } from 'services/domEvents';
import type { Observable } from 'rxjs';
import { fromEvent } from 'rxjs'; 
import { map } from 'rxjs/operators';

export class TouchEventsForElementProvider implements GetsInteractions {
  #element: HTMLElement;

  getInteractions(): InteractionsWithElement {
    return {
      start: fromEvent(this.#element, "touchstart").pipe(map(mapTouchEventToCoordinate)),
      move: fromEvent(this.#element, "touchmove").pipe(map(mapTouchEventToCoordinate)),
      end: fromEvent(this.#element, "touchend").pipe(map(mapTouchEventToCoordinate)),
    };
  }

  constructor(element: HTMLElement) {
    this.#element = element;
  }
}

const mapTouchEventToCoordinate = (ev : TouchEvent) => ({ x: ev.changedTouches[0].clientX, y: ev.changedTouches[0].clientY} : Coordinate);
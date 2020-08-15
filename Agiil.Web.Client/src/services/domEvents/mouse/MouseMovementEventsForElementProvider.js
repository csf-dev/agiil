//@flow
import type { InteractionsWithElement, Coordinate, GetsInteractions } from 'services/domEvents';
import type { Observable } from 'rxjs';
import { fromEvent } from 'rxjs'; 
import { map } from 'rxjs/operators';

export class MouseMovementEventsForElementProvider implements GetsInteractions {
  #element: HTMLElement;

  getInteractions(): InteractionsWithElement {
    return {
      start: fromEvent(this.#element, "mousedown").pipe(map(mapMouseEventToCoordinate)),
      move: fromEvent(this.#element, "mousemove").pipe(map(mapMouseEventToCoordinate)),
      end: fromEvent(this.#element, "mouseup").pipe(map(mapMouseEventToCoordinate)),
    };
  }

  constructor(element: HTMLElement) {
    this.#element = element;
  }
}

const mapMouseEventToCoordinate = (ev : MouseEvent) => ({ x: ev.clientX, y: ev.clientY} : Coordinate);
//@flow
import type { Observable } from 'rxjs';
import type { SwipeEvent } from './SwipeEvent';

export interface GetsSwipeEvents {
    getEvents() : Observable<SwipeEvent>
};
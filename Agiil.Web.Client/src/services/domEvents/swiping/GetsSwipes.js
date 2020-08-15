//@flow
import type { Observable } from 'rxjs';
import type { Swipe } from './Swipe';

export interface GetsSwipes {
    getSwipes() : Observable<Swipe>
};
//@flow
import type { ScrollFrame } from './ScrollFrame';
import type { Observable } from 'rxjs';

export interface GetsScrollFrames {
    getScrollFrames() : Observable<ScrollFrame>,
};
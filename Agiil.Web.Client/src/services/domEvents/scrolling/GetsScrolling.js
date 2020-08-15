//@flow
import type { ElementScrollInfoMap } from './ElementScrollInfoMap';
import type { Observable } from 'rxjs';

export interface GetsScrolling {
    getScrolling() : Observable<ElementScrollInfoMap>,
}
//@flow
import { getScrollFramesProvider } from './getScrollFrames';
import type { Observable } from 'rxjs';
import type { ElementScrollInfoMap } from './ElementScrollInfoMap';
import type { GetsScrolling } from './GetsScrolling';
import { ScrollingProvider } from './ScrollingProvider';

export function getScrolling(element : HTMLElement, includeChildElements : boolean = false) : Observable<ElementScrollInfoMap> {
    const provider = getScrollingProvider(element, includeChildElements);
    return provider.getScrolling();
}

export function getScrollingProvider(element : HTMLElement, includeChildElements : boolean = false) : GetsScrolling {
    const framesProvider = getScrollFramesProvider(element, includeChildElements);
    return new ScrollingProvider(framesProvider);
}
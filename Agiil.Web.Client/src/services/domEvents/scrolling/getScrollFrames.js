//@flow
import type { ScrollFrame } from './ScrollFrame';
import { fromEvent } from 'rxjs';
import type { Observable } from 'rxjs';
import type { GetsScrollFrames } from './GetsScrollFrames';
import { modernizr, tests } from 'util/modernizr';
import { throttlingInfo } from 'services/domEvents';
import { ScrollFrameProvider } from './ScrollFrameProvider';

export function getScrollFrames(element : HTMLElement, includeChildElements : boolean = false) : Observable<ScrollFrame> {
    const provider = getScrollFramesProvider(element, includeChildElements);
    return provider.getScrollFrames();
}

export function getScrollFramesProvider(element : HTMLElement, includeChildElements : boolean = false) : GetsScrollFrames {
    const
        fromEventOptions = getFromEventOptions(includeChildElements),
        // The `fromEventOptions` type should be compatible, it's a typedef bug that it's not
        // $FlowFixMe
        observable = fromEvent(element, 'scroll', fromEventOptions);
    
    return new ScrollFrameProvider(observable, throttlingInfo.frameDurationMs);
}

/**
 * Gets the 'options' parameter to `fromEvent` in a cross-browser fashion.
 * See https://developer.mozilla.org/en-US/docs/Web/API/EventTarget/addEventListener#Usage_notes
 *
 * The core issue here is that 'better' browsers support an options object (which includes a
 * useful `passive` option, to improve performance), but older browsers only accept a
 * boolean `useCapture` parameter.
 */
function getFromEventOptions(includeChilden : boolean) : EventListenerOptionsOrUseCapture {
    if(!modernizr.has(tests.passiveeventlisteners))
        return includeChilden;

    return {
        capture: includeChilden,
        passive: true
    };
}

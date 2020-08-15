//@flow
import type { GetsSwipeEvents } from './GetsSwipeEvents';
import type { SwipeOptions } from './SwipeOptions';
import { getSwipeOptions } from './getSwipeOptions';
import { getTouchInteractionProvider } from 'services/domEvents/touches';
import { getScrollingProvider } from 'services/domEvents/scrolling';
import { throttlingInfo } from 'services/domEvents';
import { SwipeEventProvider } from './SwipeEventProvider';

export function getSwipeEvents(element : HTMLElement, options? : SwipeOptions) {
    const provider = getSwipeEventsProvider(element, options);
    return provider.getEvents();
}

export function getSwipeEventsProvider(element : HTMLElement, options? : SwipeOptions) : GetsSwipeEvents {
    const
        resolvedOptions = getSwipeOptions(options),
        interactionProvider = getTouchInteractionProvider(element, resolvedOptions.allowMouseSwipes),
        scrollProvider = getScrollingProvider(element, true);

    return new SwipeEventProvider(interactionProvider, scrollProvider, throttlingInfo);
}
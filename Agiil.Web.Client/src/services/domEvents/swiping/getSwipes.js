//@flow
import type { SwipeOptions } from './SwipeOptions';
import { getSwipeOptions } from './getSwipeOptions';
import type { GetsSwipes } from './GetsSwipes';
import { getSwipeEventsProvider } from './getSwipeEvents';
import { getSwipeEventToSwipeMapper } from './getSwipeEventToSwipeMapper';
import { SwipeProvider } from './SwipeProvider';

export function getSwipes(element : HTMLElement, options? : SwipeOptions) {
    const provider = getSwipeProvider(element, options);
    return provider.getSwipes();
}

export function getSwipeProvider(element : HTMLElement, options? : SwipeOptions) : GetsSwipes {
    const
        eventsProvider = getSwipeEventsProvider(element, options),
        resolvedOptions = getSwipeOptions(options),
        mappingFunction = getSwipeEventToSwipeMapper(resolvedOptions.offsetForChildElementScrolling);

    return new SwipeProvider(eventsProvider, mappingFunction);
}
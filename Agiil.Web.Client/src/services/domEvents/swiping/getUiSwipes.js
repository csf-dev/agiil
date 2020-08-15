//@flow
import type { SwipeOptions } from './SwipeOptions';
import type { GetsUiSwipes } from './GetsUiSwipes';
import { getSwipeProvider } from './getSwipes';
import { UiSwipeProvider } from './UiSwipeProvider';

export function getUiSwipes(element : HTMLElement, options? : SwipeOptions) {
    const provider = getUiSwipeProvider(element, options);
    return provider.getUiSwipes();
}

export function getUiSwipeProvider(element : HTMLElement, options? : SwipeOptions) : GetsUiSwipes {
    const swipeProvider = getSwipeProvider(element, options);
    return new UiSwipeProvider(swipeProvider);
}
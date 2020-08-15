//@flow
import type { InteractionsWithElement } from 'services/domEvents';
import { MouseMovementEventsForElementProvider } from './MouseMovementEventsForElementProvider';

export function getMouseMovementEvents(element : HTMLElement) : InteractionsWithElement {
    const provider = new MouseMovementEventsForElementProvider(element);
    return provider.getInteractions();
}
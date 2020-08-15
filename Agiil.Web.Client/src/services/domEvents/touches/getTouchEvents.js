//@flow
import type { GetsInteractions, InteractionsWithElement } from 'services/domEvents';
import { TouchEventsForElementProvider } from './TouchEventsForElementProvider';
import { MouseMovementEventsForElementProvider } from 'services/domEvents/mouse';
import { IncludeMouseMovementsDecorator } from './IncludeMouseMovementsDecorator';

export function getTouchEvents(element : HTMLElement, includeMouseInteractions : bool = false) : InteractionsWithElement {
    const provider = getTouchInteractionProvider(element, includeMouseInteractions);
    return provider.getInteractions();
}

export function getTouchInteractionProvider(element : HTMLElement, includeMouseInteractions : boolean) : GetsInteractions {
    const touchProvider = new TouchEventsForElementProvider(element);
    if(!includeMouseInteractions) return touchProvider;

    const
        mouseProvider = new MouseMovementEventsForElementProvider(element),
        includeMouseDecorator = new IncludeMouseMovementsDecorator(touchProvider, mouseProvider);

    return includeMouseDecorator;
}
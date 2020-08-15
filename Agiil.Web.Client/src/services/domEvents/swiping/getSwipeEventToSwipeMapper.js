//@flow
import type { SwipeEventToSwipeMapper } from './SwipeEventToSwipeMapper';
import type { Swipe } from './Swipe';
import type { SwipeEvent } from './SwipeEvent';
import type { Coordinate } from 'services/domEvents';
import { getVelocity } from 'services/domEvents';

export function getSwipeEventToSwipeMapper(offsetForChildElementScrolling : boolean) : SwipeEventToSwipeMapper {
    const vectorProvider = offsetForChildElementScrolling
        ? getVectorAndOffsetForChildScrolling
        : getVectorWithoutOffsettingForChildScrolling;
    return getSwipeMapper(vectorProvider);
}

type VectorProvider = (event : SwipeEvent) => Coordinate;

function getSwipeMapper(vectorProvider : VectorProvider) : SwipeEventToSwipeMapper {
    return function mapToSwipe(event : SwipeEvent) : Swipe {
        const
            vector = vectorProvider(event),
            velocity = getVelocity(vector, event.durationMs);

        return {
            positions: event.positions,
            durationMs: event.durationMs,
            vector,
            velocity,
        };
    }
}

const getVectorWithoutOffsettingForChildScrolling : VectorProvider = (event : SwipeEvent) => {
    return {
        x: event.positions.end.x - event.positions.start.x,
        y: event.positions.end.y - event.positions.start.y,
    };
}

const getVectorAndOffsetForChildScrolling : VectorProvider = (event : SwipeEvent) => {
    const vector = getVectorWithoutOffsettingForChildScrolling(event);

    event.scrolledChildElements.map.forEach(scrolledElement => {
        /* We add the vectors (swipe & scroll) together because they will be
         * in the opposite directions.  By adding them, they will cancel
         * one-another out and tend toward zero, even though it 'looks wrong'
         * and looks as if we should be subtracting here.
         */
        vector.x += scrolledElement.vector.x;
        vector.y += scrolledElement.vector.y;
    });

    return vector;
}
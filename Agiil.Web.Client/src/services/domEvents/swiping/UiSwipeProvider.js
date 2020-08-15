//@flow
import type { GetsUiSwipes } from './GetsUiSwipes';
import type { Observable } from 'rxjs';
import { map, filter, tap } from 'rxjs/operators';
import type { UiSwipe, SwipeDirection } from './UiSwipe';
import { swipeDirections } from './UiSwipe';
import type { Swipe } from './Swipe';
import type { GetsSwipes } from './GetsSwipes';
import type { Coordinate } from 'services/domEvents';

export class UiSwipeProvider implements GetsUiSwipes {
    #swipeProvider : GetsSwipes;

    getUiSwipes() : Observable<UiSwipe> {
        return this.#swipeProvider.getSwipes()
            .pipe(
                map(mapToMaybeUiSwipe),
                tap(x => console.log(x)),
                filter(x => !!x.direction)
            );
    }

    constructor(swipeProvider : GetsSwipes) {
        this.#swipeProvider = swipeProvider;
    }
}

type MaybeUiSwipe = Swipe & { direction: ?SwipeDirection };

const minimumDistanceToCountAsSwipe = 80;
const minimumVelocityToCountAsSwipe = 0.3;
const minimumXyRatioToCountAsSwipe = 2;

function mapToMaybeUiSwipe(swipe : Swipe) : MaybeUiSwipe {
    return { ...swipe, direction: getSwipeDirection(swipe) };
}

function getSwipeDirection(swipe : Swipe) : ?SwipeDirection {
    if(swipe.velocity < minimumVelocityToCountAsSwipe) return null;

    const
        absoluteVector : Coordinate = {
            x: Math.abs(swipe.vector.x),
            y: Math.abs(swipe.vector.y)
        },
        xToYDistanceRatio = absoluteVector.x / absoluteVector.y,
        yToXDistanceRatio = absoluteVector.y / absoluteVector.x;

    if (absoluteVector.x >= minimumDistanceToCountAsSwipe
        && xToYDistanceRatio > minimumXyRatioToCountAsSwipe
        && swipe.vector.x > 0)
        return swipeDirections.right;

    if (absoluteVector.x >= minimumDistanceToCountAsSwipe
        && xToYDistanceRatio > minimumXyRatioToCountAsSwipe
        && swipe.vector.x < 0)
        return swipeDirections.left;

    if (absoluteVector.y >= minimumDistanceToCountAsSwipe
        && yToXDistanceRatio > minimumXyRatioToCountAsSwipe
        && swipe.vector.y > 0)
        return swipeDirections.down;

    if (absoluteVector.y >= minimumDistanceToCountAsSwipe
        && yToXDistanceRatio > minimumXyRatioToCountAsSwipe
        && swipe.vector.y < 0)
        return swipeDirections.up;

    return null;
}

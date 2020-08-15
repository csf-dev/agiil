//@flow
import type { Swipe } from './Swipe';

const
    swipeUp     : 'up'      = 'up',
    swipeDown   : 'down'    = 'down',
    swipeLeft   : 'left'    = 'left',
    swipeRight  : 'right'   = 'right';

export type SwipeUp = typeof swipeUp;
export type SwipeDown = typeof swipeDown;
export type SwipeLeft = typeof swipeLeft;
export type SwipeRight = typeof swipeRight;
export type SwipeDirection = SwipeUp | SwipeDown | SwipeLeft | SwipeRight;

const swipeDirections = {
    up: swipeUp,
    down: swipeDown,
    left: swipeLeft,
    right: swipeRight
};
Object.freeze(swipeDirections);
export { swipeDirections };

export type UiSwipe = Swipe & { direction: SwipeDirection };
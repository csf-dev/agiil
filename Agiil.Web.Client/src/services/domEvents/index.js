//@flow

export type { Coordinate, StartAndEndCoordinates } from './Coordinate';
export type { InteractionsWithElement } from './InteractionsWithElement';
export type { GetsInteractions } from './GetsInteractions';
export { getMouseMovementEvents } from './mouse';
export { getTouchEvents } from './touches';
export { getScrollFrames } from './scrolling';
export type { GetsThrottlingInfo } from './throttling';
export { throttlingInfo } from './throttling';
export { getVelocity } from './getVelocity';
export { getSwipes, getSwipeEvents, getUiSwipes, swipeDirections } from './swiping';
export type { SwipeOptions, Swipe, SwipeEvent, UiSwipe, SwipeDirection } from './swiping';

//@flow
import type { Swipe } from './Swipe';
import type { SwipeEvent } from './SwipeEvent';

export type SwipeEventToSwipeMapper = (event : SwipeEvent) => Swipe;
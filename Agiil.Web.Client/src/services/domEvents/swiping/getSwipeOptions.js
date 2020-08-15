//@flow
import type { SwipeOptions, ResolvedSwipeOptions } from './SwipeOptions';

export const defaultSwipeOptions : ResolvedSwipeOptions = {
    allowMouseSwipes: false,
    offsetForChildElementScrolling: true,
};

export function getSwipeOptions(options : ?SwipeOptions) : ResolvedSwipeOptions {
    return { ...defaultSwipeOptions, ...(options || {}) };
}
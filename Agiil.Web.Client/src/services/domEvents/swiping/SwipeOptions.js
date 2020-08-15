//@flow

export type ResolvedSwipeOptions = {
    allowMouseSwipes : boolean,
    offsetForChildElementScrolling : boolean,
};

export type SwipeOptions = $Shape<ResolvedSwipeOptions>;
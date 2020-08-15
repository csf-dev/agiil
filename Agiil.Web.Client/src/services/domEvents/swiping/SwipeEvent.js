//@flow
import type { StartAndEndCoordinates } from 'services/domEvents';
import type { ElementScrollInfoMap } from 'services/domEvents/scrolling';

export type SwipeGeometryAndTime = {
    positions : StartAndEndCoordinates,
    durationMs : number,
};

export type SwipeEvent = SwipeGeometryAndTime & {
    scrolledChildElements : ElementScrollInfoMap,
};

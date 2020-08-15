//@flow
import type { StartAndEndCoordinates, Coordinate } from 'services/domEvents';
import type { SwipeGeometryAndTime } from './SwipeEvent';

export type Swipe = SwipeGeometryAndTime & {
    vector : Coordinate,
    velocity : number,
}
//@flow
import type { Coordinate } from './Coordinate';

export function getVelocity(vector : Coordinate, time : number) : number {
    const
        xVelocity = vector.x / time,
        yVelocity = vector.y / time;

    return Math.sqrt(Math.pow(xVelocity, 2) + Math.pow(yVelocity, 2));
}
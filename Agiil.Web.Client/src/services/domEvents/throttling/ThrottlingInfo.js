//@flow
import type { Observable } from 'rxjs';
import { interval } from 'rxjs';

const targetFramesPerSecond = 30;

export interface GetsThrottlingInfo {
    +framesPerSecond : number,
    +frameDurationMs : number,
    +framesInterval : Observable<number>,
}

export class ThrottlingInfo implements GetsThrottlingInfo {
    get framesPerSecond() { return targetFramesPerSecond; }

    get frameDurationMs() { return Math.floor(1000 / this.framesPerSecond); }

    get framesInterval() { return interval(this.frameDurationMs); }
}

export const throttlingInfo : GetsThrottlingInfo = new ThrottlingInfo();

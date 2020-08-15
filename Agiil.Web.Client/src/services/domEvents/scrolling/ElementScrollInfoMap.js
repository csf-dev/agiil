//@flow
import type { Coordinate } from 'services/domEvents';

export type CumulativeScrollInfo = {
    scrolledElement : HTMLElement,
    start : Coordinate,
    vector : Coordinate,
};

export type ElementScrollInfoMap = { map: Map<HTMLElement,CumulativeScrollInfo> };
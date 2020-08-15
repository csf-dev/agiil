//@flow

import type { Coordinate } from './Coordinate';
import type { Observable } from 'rxjs';

export type InteractionsWithElement = {
    start: Observable<Coordinate>,
    move: Observable<Coordinate>,
    end: Observable<Coordinate>,
};

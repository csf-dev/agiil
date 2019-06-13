//@flow
import { BuildsObjectReducer, BuildsReducer } from './BuildsReducer';
import { ObjectReducerBuilder } from './ObjectReducerBuilder';
import { PrimitiveReducerBuilder } from './PrimitiveReducerBuilder';

export function buildObjectReducer<S : {}>(defaultState : S | (?S) => S) : BuildsObjectReducer<S> {
    return new ObjectReducerBuilder<S>(defaultState);
}

export function buildPrimitiveReducer<S>(defaultState : S | (?S) => S) : BuildsReducer<S> {
    return new PrimitiveReducerBuilder<S>(defaultState);
}

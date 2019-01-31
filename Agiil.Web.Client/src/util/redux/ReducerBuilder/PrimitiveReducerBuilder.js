//@flow
import type { Reducer as Redux$Reducer } from 'redux';
import type { AnyAction } from '../../../Action';
import { BuildsReducer, AcceptsReducer } from './BuildsReducer';
import type { Reducer } from './Reducer';
import { PrimitiveReducerReceiver } from './ReducerReceivers';
import { createReducer } from './createReducer';

/**
 * Type aliases
 * ------------
 *
 * S = State
 * T = Action type (key literal)
 * A = Action
 * B = Reducer builder
 * P = Parent state
 * K = Object key
 */

export class PrimitiveReducerBuilder<S> implements BuildsReducer<S> {
    #actionReducers : Map<string,Reducer<S,AnyAction>>;
    #defaultState : S | () => S;

    forTypeKey<T>(type : T) : AcceptsReducer<S,BuildsReducer<S>,T> {
        if(!type) throw new Error('An action type must be specified');
        const typeStr : string = (type : any);
        if(this.#actionReducers.has(typeStr)) throw new Error(`An action reducer has already been registered for the type '${typeStr}'.
Only one action handler may be registered per type name.`);
        const addCallback = (reducer : Reducer<S,AnyAction>) => { this.#actionReducers.set(typeStr, reducer); }
        return new PrimitiveReducerReceiver<S,PrimitiveReducerBuilder<S>,T>(this, addCallback);
    }

    build() : Redux$Reducer<S,AnyAction> {
        return createReducer<S>(this.#defaultState, this.#actionReducers);
    }

    constructor(defaultState : S | () => S) {
        this.#actionReducers = new Map();
        this.#defaultState = defaultState;
    }
}
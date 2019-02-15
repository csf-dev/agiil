//@flow
import type { Reducer as Redux$Reducer } from 'redux';
import type { AnyAction } from 'models';
import { BuildsObjectReducer, AcceptsReducer, AcceptsChildReducer } from './BuildsReducer';
import type { Reducer } from './Reducer';
import { ObjectReducerReceiver, ChildReducerReceiver } from './ReducerReceivers';
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

export class ObjectReducerBuilder<S : {}> implements BuildsObjectReducer<S> {
    #actionReducers : Map<string,Reducer<S,AnyAction>>;
    #childReducers : Map<string,Reducer<mixed,AnyAction>>;
    #defaultState : S | () => S;
    #filterByComponentId : bool;

    filterByComponentId() : BuildsObjectReducer<S> {
        this.#filterByComponentId = true;
        return this;
    }

    forTypeKey<T>(type : T) : AcceptsReducer<S,BuildsObjectReducer<S>,T> {
        if(!type) throw new Error('An action type must be specified');
        const typeStr : string = (type : any);
        if(this.#actionReducers.has(typeStr)) throw new Error(`An action reducer has already been registered for the type '${typeStr}'.
Only one action handler may be registered per type name.`);
        const addCallback = (reducer : Reducer<S,AnyAction>) => { this.#actionReducers.set(typeStr, reducer); }
        return new ObjectReducerReceiver<S,ObjectReducerBuilder<S>,T>(this, addCallback);
    }

    forChild<K : $Keys<S>>(keyName : K) : AcceptsChildReducer<$ElementType<S,K>,S,BuildsObjectReducer<S>> {
        if(this.#childReducers.has(keyName)) throw new Error(`A child reducer has already been registered for the key '${keyName}'.
Only one child handler may be registered per key name.`);
        const addCallback = (reducer : Reducer<mixed,AnyAction>) => { this.#childReducers.set(keyName, reducer); }
        return new ChildReducerReceiver<$ElementType<S,K>,S,BuildsObjectReducer<S>>(this, addCallback);
    }

    build() : Redux$Reducer<S,AnyAction> {
        return createReducer<S>(this.#defaultState, this.#actionReducers, this.#childReducers, this.#filterByComponentId, true);
    }

    constructor(defaultState : S | () => S) {
        this.#actionReducers = new Map();
        this.#childReducers = new Map();
        this.#defaultState = defaultState;
        this.#filterByComponentId = false;
    }
}
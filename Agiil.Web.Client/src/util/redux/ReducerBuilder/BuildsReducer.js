//@flow
import type { Reducer as Redux$Reducer } from 'redux';
import type { AnyAction, Action } from 'models';
import type { ActionReducer, Reducer } from './Reducer';

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

export interface BuildsReducer<S> {
    filterByComponentId() : BuildsReducer<S>;
    forTypeKey<T>(type : T) : AcceptsReducer<S,BuildsReducer<S>,T>;
    build() : Redux$Reducer<S,AnyAction>;
}

export interface BuildsObjectReducer<S : {}> {
    filterByComponentId() : BuildsObjectReducer<S>;
    forTypeKey<T>(type : T) : AcceptsReducer<S,BuildsObjectReducer<S>,T>;
    forChild<K : $Keys<S>>(keyName : K) : AcceptsChildReducer<$ElementType<S,K>,S,BuildsObjectReducer<S>>;
    build() : Redux$Reducer<S,AnyAction>;
}

type AnyBuilder<S> = BuildsObjectReducer<S> | BuildsReducer<S>;

export interface AcceptsReducer<S, +B : AnyBuilder<S>, T> {
    andAction<A : Action<T,any,any>>(reducingFunc : ActionReducer<T,S,A>) : B;
}

export interface AcceptsChildReducer<S, P : {}, B : BuildsObjectReducer<P>> {
    andReducer<A : AnyAction>(reducingFunc : Reducer<S,A>) : B;
}
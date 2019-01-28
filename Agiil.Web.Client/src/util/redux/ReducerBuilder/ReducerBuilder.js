//@flow
import type { Reducer as Redux$Reducer } from 'redux';
import type { AnyAction, Action } from '../../../Action';
import { BuildsObjectReducer, BuildsReducer, AcceptsReducer, AcceptsChildReducer } from './BuildsReducer';
import type { ActionReducer, Reducer } from '../Reducer';

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
    forTypeKey<T>(type : T) : AcceptsReducer<S,BuildsObjectReducer<S>,T> {
        throw new Error('Not implemented');
    }

    forChild<K : $Keys<S>>(keyName : K) : AcceptsChildReducer<$ElementType<S,K>,S,BuildsObjectReducer<S>> {
        throw new Error('Not implemented');
    }

    build() : Redux$Reducer<S,AnyAction> {
        throw new Error('Not implemented');
    }
}

export class PrimitiveReducerBuilder<S> implements BuildsReducer<S> {
    forTypeKey<T,>(type : T) : AcceptsReducer<S,BuildsReducer<S>,T> {
        throw new Error('Not implemented');
    }

    build() : Redux$Reducer<S,AnyAction> {
        throw new Error('Not implemented');
    }
}

export class ObjectReducerReceiver<S : {}, B : BuildsObjectReducer<S>, T> implements AcceptsReducer<S,B,T> {
    reducingFunc : mixed;
    builder : B;

    andAction<A : Action<T>>(reducingFunc : ActionReducer<T,S,A>) : B {
        this.reducingFunc = reducingFunc;
        return this.builder;
    }

    constructor(builder : B) {
        this.builder = builder;
    }
}

export class PrimitiveReducerReceiver<S, B : BuildsReducer<S>, T> implements AcceptsReducer<S,B,T>  {
    reducingFunc : mixed;
    builder : B;

    andAction<A : Action<T>>(reducingFunc : ActionReducer<T,S,A>) : B {
        this.reducingFunc = reducingFunc;
        return this.builder;
    }

    constructor(builder : B) {
        this.builder = builder;
    }
}

export class ChildReducerReceiver<S,P : {},B : BuildsObjectReducer<P>> implements AcceptsChildReducer<S,P,B> {
    reducingFunc : mixed;
    builder : B;

    andReducer<A : AnyAction>(reducingFunc : Reducer<S,A>) : B {
        this.reducingFunc = reducingFunc;
        return this.builder;
    }

    constructor(builder : B) {
        this.builder = builder;
    }
}

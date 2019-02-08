//@flow
import type { AnyAction, Action } from 'models';
import { BuildsObjectReducer, BuildsReducer, AcceptsReducer, AcceptsChildReducer } from './BuildsReducer';
import type { ActionReducer, Reducer } from './Reducer';

export class ObjectReducerReceiver<S : {}, B : BuildsObjectReducer<S>, T> implements AcceptsReducer<S,B,T> {
    #builder : B;
    #callback : (reducer : Reducer<S,AnyAction>) => void;

    andAction<A : Action<T,any,any>>(reducingFunc : ActionReducer<T,S,A>) : B {
        const cb = this.#callback;
        cb((reducingFunc : any));
        return this.#builder;
    }

    constructor(builder : B, callback : (reducer : Reducer<S,AnyAction>) => void) {
        this.#builder = builder;
        this.#callback = callback;
    }
}

export class PrimitiveReducerReceiver<S, B : BuildsReducer<S>, T> implements AcceptsReducer<S,B,T>  {
    #builder : B;
    #callback : (reducer : Reducer<S,AnyAction>) => void;

    andAction<A : Action<T,any,any>>(reducingFunc : ActionReducer<T,S,A>) : B {
        const cb = this.#callback;
        cb((reducingFunc : any));
        return this.#builder;
    }

    constructor(builder : B, callback : (reducer : Reducer<S,AnyAction>) => void) {
        this.#builder = builder;
        this.#callback = callback;
    }
}

export class ChildReducerReceiver<S,P : {},B : BuildsObjectReducer<P>> implements AcceptsChildReducer<S,P,B> {
    #callback : (reducer : Reducer<mixed,AnyAction>) => void;
    #builder : B;

    andReducer<A : AnyAction>(reducingFunc : Reducer<S,A>) : B {
        const cb = this.#callback;
        cb((reducingFunc : any));
        return this.#builder;
    }

    constructor(builder : B, callback : (reducer : Reducer<mixed,AnyAction>) => void) {
        this.#builder = builder;
        this.#callback = callback;
    }
}

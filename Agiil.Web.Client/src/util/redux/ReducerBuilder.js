//@flow
import type { Reducer } from 'redux';
import type { AnyAction, Action } from '../../Action';

export type ReducingFunction<ActionType,TState,-TAction : Action<ActionType>>
    = (state : ?TState, action : TAction) => TState;

export type UntypedReducingFunction<TState,-TAction : AnyAction>
    = (state : ?TState, action : TAction) => TState;

type AnyBuilder<TState> = BuildsObjectReducer<TState> | BuildsPrimitiveReducer<TState>;

export interface BuildsObjectReducer<TState : {}> {
    forTypeKey<ActionType>(type : ActionType) : AcceptsReducer<TState, BuildsObjectReducer<TState>, ActionType>;

    forChild<TKey : $Keys<TState>>(keyName : TKey) : AcceptsChildReducer<$ElementType<TState,TKey>,TState,BuildsObjectReducer<TState>>;

    build() : Reducer<TState,AnyAction>;
}

export interface BuildsPrimitiveReducer<TState> {
    forTypeKey<ActionType>(type : ActionType) : AcceptsReducer<TState,BuildsPrimitiveReducer<TState>,ActionType>;

    build() : Reducer<TState,AnyAction>;
}

export interface AcceptsReducer<TState, TBuilder : AnyBuilder<TState>, ActionType> {
    andAction<TAction : Action<ActionType>>(reducingFunc : ReducingFunction<ActionType,TState,TAction>) : TBuilder;
}

export interface AcceptsChildReducer<TState, TParent : {}, TBuilder : BuildsObjectReducer<TParent>> {
    andReducer<TAction>(reducingFunc : UntypedReducingFunction<TState,TAction>) : TBuilder;
}

export class ObjectReducerBuilder<TState : {}> implements BuildsObjectReducer<TState> {
    forTypeKey<ActionType>(type : ActionType) : AcceptsReducer<TState,BuildsObjectReducer<TState>,ActionType> {
        throw new Error('Not implemented');
    }

    forChild<TKey : $Keys<TState>>(keyName : TKey) : AcceptsChildReducer<$ElementType<TState,TKey>,TState,BuildsObjectReducer<TState>> {
        throw new Error('Not implemented');
    }

    build() : Reducer<TState,AnyAction> {
        throw new Error('Not implemented');
    }
}

export class PrimitiveReducerBuilder<TState> implements BuildsPrimitiveReducer<TState> {
    forTypeKey<ActionType,>(type : ActionType) : AcceptsReducer<TState,BuildsPrimitiveReducer<TState>,ActionType> {
        throw new Error('Not implemented');
    }

    build() : Reducer<TState,AnyAction> {
        throw new Error('Not implemented');
    }
}

export class ObjectReducerReceiver<TState : {}, TBuilder : BuildsObjectReducer<TState>, ActionType> implements AcceptsReducer<TState, TBuilder, ActionType> {
    andAction<TAction : Action<ActionType>>(reducingFunc : ReducingFunction<ActionType,TState,TAction>) : TBuilder {
        throw new Error('Not implemented');
    }
}

export class PrimitiveReducerReceiver<TState, TBuilder : BuildsPrimitiveReducer<TState>, ActionType> implements AcceptsReducer<TState, TBuilder, ActionType> {
    andAction<TAction : Action<ActionType>>(reducingFunc : ReducingFunction<ActionType,TState,TAction>) : TBuilder {
        throw new Error('Not implemented');
    }
}

export class ChildReducerReceiver<TState,TParent : {},TBuilder : BuildsObjectReducer<TParent>> implements AcceptsChildReducer<TState,TParent,TBuilder> {
    andReducer<TAction>(reducingFunc : UntypedReducingFunction<TState,TAction>) : TBuilder {
        throw new Error('Not implemented');
    }
}

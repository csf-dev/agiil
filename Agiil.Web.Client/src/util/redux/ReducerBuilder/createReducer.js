//@flow
// import type { Reducer } from 'redux';
// import type { AnyAction } from '../../Action';

// TODO: Switch ths to a builder pattern instead.  We've got to deal with at least three separate
// concepts here:
// 
// * Reducers for specific action types
// * Reducers for child state
// * The default state value if state is undefined and no actions match

/*

export default function createReducer<TState>(defaultState : TState,
                                              actionTypeReducers : ChildReducers<TState>,
                                              childReducers : ChildReducers<mixed>) : Reducer<TState,AnyAction> {
    const factory = new ReducerMapReducerFactory<TState>(defaultState);

    if(Array.isArray(actionTypeReducers))
        actionTypeReducers.forEach(namedFunc => factory.addChild(namedFunc.type, namedFunc.func));
    else {
        const objMap = actionTypeReducers;
        for (const name in objMap) {
            if (!objMap.hasOwnProperty(name)) continue;
            if(typeof objMap[name] !== 'function') continue;
            const func = objMap[name];
            factory.addChild(name, func);
        }
    }

    return factory.getReducer();
}

export type ReducingFunction<TState,-TAction : AnyAction>
    = (state : ?TState, action : TAction) => TState;

export type NamedReducingFunction<TState> = {
    type : string,
    func : ReducingFunction<TState,AnyAction>
}

export type ReducingFunctionObjectMap = {};

export type ChildReducers<TState> = Array<NamedReducingFunction<TState>> | ReducingFunctionObjectMap;

export class ReducerMapReducerFactory<TState> {
    map : Map<string,ReducingFunction<TState,AnyAction>>;
    defaultState : TState;

    addChild(actionType : string, reducer : ReducingFunction<TState,AnyAction>) {
        if(this.map.has(actionType))
            throw new Error(`There is already a reducing function registered for action type '${actionType}'. 
Reducing functions must not registered twice.`);

        this.map.set(actionType, reducer);
    }

    getReducer() : Reducer<TState,AnyAction> {
        return (state : ?TState, action : AnyAction) => {
            const actionReducer = this.map.get(action.type);
            if(!actionReducer) return state || this.defaultState;
            return actionReducer(state, action);
        }
    }

    constructor(defaultState : TState) {
        this.map = new Map();
        this.defaultState = defaultState;
    }
}

*/
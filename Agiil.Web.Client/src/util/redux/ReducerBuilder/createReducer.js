//@flow
import type { Reducer as Redux$Reducer } from 'redux';
import type { AnyAction } from '../../../Action';
import type { Reducer } from './Reducer';

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

export function createReducer<S>(defaultState : S | () => S,
                                 actionReducers : Map<string,Reducer<S,AnyAction>>,
                                 children? : Map<string,Reducer<mixed,AnyAction>>) : Redux$Reducer<S,AnyAction> {
    const childReducers : Map<string,Reducer<mixed,AnyAction>> = children || new Map();

    return function(state : ?S, action : AnyAction) : S {
        const newState = getState<S>(state, defaultState);

        for (const childMapping of childReducers.entries()) {
            const [key, reducer] = childMapping, childState = (newState : any)[key];
            (newState : any)[key] = reducer(childState, action);
        }


        for (const actionMapping of actionReducers.entries()) {
            const [type, reducer] = actionMapping;
            if(action.type === type) return reducer(newState, action);
        }

        return newState;
    }
}

function getState<S>(state : ?S, defaultState : S | () => S) : S {
    if(state === undefined) return getDefaultState<S>(defaultState);
    if(state === null) return getDefaultState<S>(defaultState);

    return state;
}

function getDefaultState<S>(defaultState : S | () => S) : S {
    if(typeof defaultState === 'function') return defaultState();
    return defaultState;
}
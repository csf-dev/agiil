//@flow
import type { Reducer as Redux$Reducer } from 'redux';
import type { AnyAction, ComponentId } from '../../../Action';
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
                                 children? : Map<string,Reducer<mixed,AnyAction>>,
                                 filterActionsByComponentId : bool,
                                 isObject : bool) : Redux$Reducer<S,AnyAction> {
    const childReducers : Map<string,Reducer<mixed,AnyAction>> = children || new Map();

    return function(state : ?S, action : AnyAction) : S {
        const newState = getState<S>(state, defaultState, isObject);
        const componentIdState = getStateAsComponentId(newState);

        for (const childMapping of childReducers.entries()) {
            const [key, reducer] = childMapping, childState = (newState : any)[key];
            (newState : any)[key] = reducer(childState, action);
        }

        for (const actionMapping of actionReducers.entries()) {
            const [type, reducer] = actionMapping;
            
            if(actionMatches(action, type, componentIdState, filterActionsByComponentId))
                return reducer(newState, action);
        }

        return newState;
    }
}

function getStateAsComponentId<S>(state : S) : ?ComponentId {
    if(state === null) return undefined;
    if(typeof state !== 'object') return undefined;
    if(!state.hasOwnProperty('componentId')) return undefined;

    return ((state : any) : ComponentId)
}

function getState<S>(state : ?S, defaultState : S | () => S, isObject : bool) : S {
    if(state === undefined) return getDefaultState<S>(defaultState);
    if(state === null) return getDefaultState<S>(defaultState);
    if(isObject) return {...state};
    return state;
}

function getDefaultState<S>(defaultState : S | () => S) : S {
    if(typeof defaultState === 'function') return defaultState();
    return defaultState;
}

function actionMatches(action : AnyAction, type : string, state : ?ComponentId, filterByComponentId : bool) : bool {
    if(!actionTypeMatches(action, type)) return false;
    if(!filterByComponentId) return true;
    return actionComponentIdMatches(action, state);
}

function actionComponentIdMatches(action : AnyAction, state : ?ComponentId) : bool {
    const stateComponentId : ?string = state?.componentId;
    const actionComponentId : ?string = action?.meta?.componentId;

    return !!stateComponentId && stateComponentId === actionComponentId;
}

function actionTypeMatches(action : AnyAction, type : string) : bool {
    return action.type === type;
}
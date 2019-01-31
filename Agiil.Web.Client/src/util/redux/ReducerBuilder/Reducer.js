//@flow
import type { AnyAction, Action } from '../../../Action';

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

export type ActionReducer<T,S,-A : Action<T,any,any>>
    = (state : S | void, action : A) => S;

export type Reducer<S,-A : AnyAction>
    = (state : S | void, action : A) => S;

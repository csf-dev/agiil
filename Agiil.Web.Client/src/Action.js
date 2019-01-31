//@flow
export type Action<+T,+P,+M> = {|
    +type : T,
    +payload : P,
    +error? : bool,
    +meta? : M
|};

export type ErrorAction<+T,+P : Error,+M> = Action<T,P,M> & {|
    error : true
|};

export type AnyAction = Action<any,any,any>;

export type ComponentId = {
    id : string
};

//@flow

export type AnyAction = { +type : string };
export type Action<T> = { +type : T };
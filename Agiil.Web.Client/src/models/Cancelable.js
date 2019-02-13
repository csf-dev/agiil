//@flow

export interface Cancelable<T> {
    +promise : Promise<T>;
    +id : string;
    cancel() : void;
    map<TNewType>((val : T) => TNewType) : Cancelable<TNewType>
};
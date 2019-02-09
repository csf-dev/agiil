//@flow

export type Cancelable<T> = {
    promise : Promise<T>;
    requestId : string;
    cancel() : void;
};
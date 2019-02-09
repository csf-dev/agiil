//@flow
import type { Cancelable } from 'models';

export interface GetsDataAsync<TResponse> {
    getDataAsync() : Cancelable<TResponse>;
}

export interface RequestsDataAsync<TRequest,TResponse> {
    getDataAsync(request : TRequest) : Cancelable<TResponse>;
}
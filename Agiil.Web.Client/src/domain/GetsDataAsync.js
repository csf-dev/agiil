//@flow

export interface GetsDataAsync<TResponse> {
    getDataAsync() : Promise<TResponse>;
}

export interface RequestsDataAsync<TRequest,TResponse> {
    getDataAsync(request : TRequest) : Promise<TResponse>;
}
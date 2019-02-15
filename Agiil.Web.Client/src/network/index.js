//@flow
import { NetworkServiceFactory } from './NetworkServiceFactory';
import { ApiUrlServiceFactoryDecorator } from './ApiUrlServiceFactoryDecorator';
import type { Cancelable } from 'models';

export interface SendsNetworkRequests<TRequest,TResponse> {
    sendRequest(request? : TRequest) : Cancelable<TResponse>;
}

export interface GetsNetworkRequestSender {
    getJson<TRequest : {},TResponse>(url : string) : SendsNetworkRequests<TRequest,TResponse>;
    postJson<TRequest,TResponse>(url : string) : SendsNetworkRequests<TRequest,TResponse>;
};

const requestServiceFactory = getNetworkRequestSenderFactory();
export { requestServiceFactory };

function getNetworkRequestSenderFactory() : GetsNetworkRequestSender {
    const baseFactory = new NetworkServiceFactory();
    const baseUrlDecorator = new ApiUrlServiceFactoryDecorator(baseFactory);
    return baseUrlDecorator;
}
//@flow
import { SendsNetworkRequests, GetsNetworkRequestSender } from '.';

const apiBaseUrl = 'api/v1/';

export class ApiUrlServiceFactoryDecorator implements GetsNetworkRequestSender {
    wrapped : GetsNetworkRequestSender;

    getJson<TRequest : {},TResponse>(url : string) : SendsNetworkRequests<TRequest,TResponse> {
        return this.wrapped.getJson(apiBaseUrl + url);
    }
    postJson<TRequest,TResponse>(url : string) : SendsNetworkRequests<TRequest,TResponse> {
        return this.wrapped.postJson(apiBaseUrl + url);
    }

    constructor(wrapped : GetsNetworkRequestSender) {
        this.wrapped = wrapped;
    }
}
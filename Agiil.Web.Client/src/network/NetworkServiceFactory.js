//@flow
import { SendsNetworkRequests, GetsNetworkRequestSender } from '.';
import JsonAjaxGetRequest from './JsonAjaxGetRequest';
import JsonAjaxPostRequest from './JsonAjaxPostRequest';

export class NetworkServiceFactory implements GetsNetworkRequestSender {
    getJson<TRequest : {},TResponse>(url : string) : SendsNetworkRequests<TRequest,TResponse> {
        return new JsonAjaxGetRequest<TRequest,TResponse>(url);
    }
    postJson<TRequest,TResponse>(url : string) : SendsNetworkRequests<TRequest,TResponse> {
        return new JsonAjaxPostRequest<TRequest,TResponse>(url);
    }
}
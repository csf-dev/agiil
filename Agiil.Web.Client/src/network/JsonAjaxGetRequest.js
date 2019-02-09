//@flow
import xhrSendToPromise from './xhrSendToPromise';
import { SendsNetworkRequests } from '.';
import { getUrlWithQuerystringParams } from './querystring';
import type { Cancelable } from 'models';
import { getJsonXhr } from './getXhr';

export default class JsonAjaxGetRequest<TRequest : {},TResponse> implements SendsNetworkRequests<TRequest,TResponse> {
    url : string;

    sendRequest(request? : TRequest) : Cancelable<TResponse> {
        const url = getUrlWithQuerystringParams(this.url, request);
        const xhr = getJsonXhr(url, 'GET');
        const cancelableXhr = xhrSendToPromise(xhr);
        return {
            cancel: () => cancelableXhr.cancel(),
            requestId: cancelableXhr.requestId,
            promise: cancelableXhr.promise.then(x => (x.response : TResponse))
        };
    }

    constructor(url : string) {
        this.url = url;
    }
}


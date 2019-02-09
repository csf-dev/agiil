//@flow
import xhrSendToPromise from './xhrSendToPromise';
import { SendsNetworkRequests } from '.';
import type { Cancelable } from 'models';
import { getJsonXhr } from './getXhr';

export default class JsonAjaxPostRequest<TRequest,TResponse> implements SendsNetworkRequests<TRequest,TResponse> {
    url : string;

    sendRequest(request? : TRequest) : Cancelable<TResponse> {
        const xhr = getJsonXhr(this.url, 'POST');
        const body = getRequestBody(request);
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

function getRequestBody(request? : mixed) : ?string {
    return (request !== undefined)? JSON.stringify(request) : null;
}

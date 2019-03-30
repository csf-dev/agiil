//@flow
import getCancelableXhr from './getCancelableXhr';
import { SendsNetworkRequests } from '.';
import type { Cancelable } from 'models';
import { getJsonXhr } from './getXhr';

export default class JsonAjaxPostRequest<TRequest,TResponse> implements SendsNetworkRequests<TRequest,TResponse> {
    url : string;

    sendRequest(request? : TRequest) : Cancelable<TResponse> {
        const xhr = getJsonXhr(this.url, 'POST');
        const body = getRequestBody(request);
        const cancelableXhr = getCancelableXhr(xhr, body);
        return cancelableXhr.map<TResponse>(x => (x.response : TResponse));
    }

    constructor(url : string) {
        this.url = url;
    }
}

function getRequestBody(request? : mixed) : ?string {
    return (request !== undefined)? JSON.stringify(request) : null;
}

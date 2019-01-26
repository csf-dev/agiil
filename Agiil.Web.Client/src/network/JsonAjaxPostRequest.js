//@flow
import xhrSendToPromise from './xhrSendToPromise';
import { SendsNetworkRequests } from '.';

export default class JsonAjaxPostRequest<TRequest,TResponse> implements SendsNetworkRequests<TRequest,TResponse> {
    url : string;

    async sendRequest(request? : TRequest) : Promise<TResponse> {
        const xhr = getXhr(this.url);
        const body = getRequestBody(request);
        const resultXhr = await xhrSendToPromise(xhr, body);
        return (resultXhr.response : TResponse);
    }

    constructor(url : string) {
        this.url = url;
    }
}

function getXhr(url : string) : XMLHttpRequest {
    const xhr = new XMLHttpRequest();
    xhr.open('POST', url);
    xhr.setRequestHeader('Accept', 'application/json, text/javascript, text/json, text/plain');
    xhr.responseType = 'json';
    return xhr;
}

function getRequestBody(request? : mixed) : ?string {
    return (request !== undefined)? JSON.stringify(request) : null;
}

//@flow
import xhrSendToPromise from './xhrSendToPromise';
import { SendsNetworkRequests } from '.';
import { getUrlWithQuerystringParams } from './querystring';

export default class JsonAjaxGetRequest<TRequest : {},TResponse> implements SendsNetworkRequests<TRequest,TResponse> {
    url : string;

    async sendRequest(request? : TRequest) : Promise<TResponse> {
        const url = getUrlWithQuerystringParams(this.url, request);
        const xhr = getXhr(url);
        const resultXhr = await xhrSendToPromise(xhr);
        return (resultXhr.response : TResponse);
    }

    constructor(url : string) {
        this.url = url;
    }
}

function getXhr(url : string) : XMLHttpRequest {
    const xhr = new XMLHttpRequest();
    xhr.open('GET', url);
    xhr.setRequestHeader('Accept', 'application/json, text/javascript, text/json, text/plain');
    xhr.responseType = 'json';
    return xhr;
}

//@flow

export function getJsonXhr(url : string, method : string) : XMLHttpRequest {
    const xhr = new XMLHttpRequest();
    xhr.open(method, url);
    xhr.setRequestHeader('Accept', 'application/json, text/javascript, text/json, text/plain');
    xhr.responseType = 'json';
    return xhr;
}
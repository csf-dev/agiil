//@flow
import type { Cancelable } from 'models';
import { v4 as uuid } from 'uuid';

export default function xhrSendToPromise(xhr : XMLHttpRequest, body? : mixed) : Cancelable<XMLHttpRequest> {
    const promise = new Promise((resolve, reject) => setupReadyStateChangeHandler(xhr, resolve, reject));
    xhr.send(body);
    
    return {
        cancel: () => xhr.abort(),
        requestId: getRequestId(),
        promise
    };
}

function setupReadyStateChangeHandler(xhr : XMLHttpRequest,
                                      resolve : (xhr : XMLHttpRequest) => void,
                                      reject : (xhr : XMLHttpRequest) => void) : void {
    xhr.onreadystatechange = () => {
        if(xhr.readyState !== 4) return;

        if(xhr.status >= 200 && xhr.status < 300) resolve(xhr);
        else if(xhr.status >= 400) reject(xhr);
    }
}

const getRequestId = () => uuid();
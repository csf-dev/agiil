//@flow
import type { Cancelable } from 'models';
import { CancelablePromise } from 'util/CancelablePromise';

export default function getCancelableXhr(xhr : XMLHttpRequest, body? : mixed) : Cancelable<XMLHttpRequest> {
    const promise = new Promise((resolve, reject) => setupReadyStateChangeHandler(xhr, resolve, reject));
    xhr.send(body);
    
    return new CancelablePromise(promise, () => xhr.abort());
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

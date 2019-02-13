//@flow
import { Cancelable } from 'models';
import { v4 as uuid } from 'uuid';

export class CancelablePromise<T> implements Cancelable<T> {
    #id : string;
    #cancel : () => void;
    #promise : Promise<T>;

    get id() { return this.#id; }
    get promise() : Promise<T> { return this.#promise; }

    cancel() {
        const cancelFunc = this.#cancel;
        cancelFunc();
    }

    map<TNew>(mapper : (val : T) => TNew) : Cancelable<TNew> {
        const mappedPromise = this.#promise.then(mapper);
        return new CancelablePromise(this.#promise.then(mapper), this.#cancel, this.#id);
    }

    constructor(promise : Promise<T>, cancelFunc : () => void, id? : string) {
        this.#promise = promise;
        this.#cancel = cancelFunc;
        this.#id = id || uuid();
    }
}


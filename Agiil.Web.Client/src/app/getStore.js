//@flow
import { createStore, applyMiddleware } from 'redux';
import type { AnyStore } from 'util/redux/AnyStore';
import rootReducer from 'reducers';
import thunk from 'redux-thunk';
import mandatory from 'util/mandatory';

export class StoreFactory {
    #store : ?AnyStore;

    isCreated() { return this.#store != null; }

    getStore(initial? : mixed) : AnyStore {
        if(initial && this.isCreated())
            console.warn('The store has already been created with initial data. The initial data is being ignored.');

        if(!this.isCreated()) {
            this.#store = createNewStore(initial);
        }

        return mandatory(this.#store);
    }

    constructor() {
        this.#store = null;
    }
}

function createNewStore(initial : ?mixed) : AnyStore {
    return createStore<any,any,any>(rootReducer, initial, applyMiddleware(thunk));
}

const provider = new StoreFactory();

export default function getStore(initial? : mixed) {
    return provider.getStore(initial);
}
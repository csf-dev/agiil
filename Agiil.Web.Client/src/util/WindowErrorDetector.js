//@flow

export type ErrorHandler = (error : Error) => void;

export type ErrorEvent = Event & {
    message : string,
    filename : string,
    lineno : number,
    colno : number,
    error : Error,
};

export interface DetectsErrorsInWindow {
    removeUnhandledErrorHandler(handler : ErrorHandler) : void,
    addUnhandledErrorHandler(handler : ErrorHandler) : void,
};

export class WindowErrorDetector implements DetectsErrorsInWindow {
    #handlers : Set<ErrorHandler>;

    onError(event : ErrorEvent) {
        console.error('Unhandled error event', event.error);

        const handlers = this.#handlers;
        handlers.forEach(handler => {
            try { handler(event.error); }
            catch(error) {
                console.error("Encountered an whilst handling an unhandled error, bailing out for sanity's sake!", error);
            }
        });
    }

    removeUnhandledErrorHandler(handler : ErrorHandler) : void {
        if(!handler) return;
        const handlers = this.#handlers;
        handlers.delete(handler);
    }

    addUnhandledErrorHandler(handler : ErrorHandler) : void {
        if(!handler) return;
        const handlers = this.#handlers;
        handlers.add(handler);
    }

    constructor(win : any) {
        if(!win || typeof(win.addEventListener) != 'function') throw new Error('A DOM window object is required');
        this.#handlers = new Set<ErrorHandler>();
        const $self = this;
        win.addEventListener('error', (err : ErrorEvent) => $self.onError(err));
    }
}

export default function getWindowErrorDetector() : DetectsErrorsInWindow {
    return new WindowErrorDetector(window);
}
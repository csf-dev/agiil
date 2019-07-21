//@flow
import type { Middleware, MiddlewareAPI } from 'redux';
import type { ModalDialogState } from 'models/modals';
import type { AnyAction } from 'models';
import type { Dispatch } from 'redux';
import { querySelectorMandatory } from 'util/dom';

/* This middleware monitors the Redux store state and (depending upon whether a modal window is visible or not)
 * toggles the HTML class attribute of the page's <html> element, to match.
 */

const htmlElement = querySelectorMandatory('html');
const modalVisibleClassName = 'modal-visible';

export const syncHeadWithModalState : Middleware<{modalVisibility : ModalDialogState}, AnyAction, Dispatch<AnyAction>> = store => next => action => {
    const output = next(action);

    const state = store.getState();
    if(state?.modalVisibility?.visible)
        htmlElement.classList.add(modalVisibleClassName);
    else
        htmlElement.classList.remove(modalVisibleClassName);

    return output;
};
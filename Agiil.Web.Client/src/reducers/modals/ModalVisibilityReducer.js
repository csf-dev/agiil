//@flow
import type { ModalDialogState } from 'models/modals';
import type { AnyAction } from 'models';
import { OpenChangePanelDialog, CloseChangePanelDialog } from 'actions/pageLayout/ChangeActivePanel';

const
    actionTypesWhichOpenTheModal = [
        OpenChangePanelDialog
    ],
    actionTypesWhichCloseTheModal = [
        CloseChangePanelDialog
    ];

const defaultState : ModalDialogState = {
    visible: false
};

function getState(state : ?ModalDialogState) {
    return { ...defaultState, ...state };
}

export function ModalVisibilityReducer(state : ?ModalDialogState, action : AnyAction) {
    const type = action.type;

    if(actionTypesWhichOpenTheModal.includes(type))
        return { ...getState(state), visible: true };

    if(actionTypesWhichCloseTheModal.includes(type))
        return { ...getState(state), visible: false };

    return { ...getState(state) };
}
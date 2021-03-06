//@flow
import { combineReducers } from 'redux';

import { LabelChooserReducer } from './labels';
import { AddACommentReducer, TicketDetailReducer } from './ticket';
import { ActivePanelReducer } from './pageLayout';
import { ModalVisibilityReducer } from './modals';
import type { AnyAction } from 'models';

const rootReducer = combineReducers<any,AnyAction>({
    labelChooser: LabelChooserReducer,
    addComment: AddACommentReducer,
    ticket: TicketDetailReducer,
    activePagePanel: ActivePanelReducer,
    modalVisibility: ModalVisibilityReducer,
});

export default rootReducer;
//@flow
import { combineReducers } from 'redux';

import { LabelChooserReducer } from './labels';
import { AddACommentReducer, TicketDetailReducer } from './ticket';

const rootReducer = combineReducers({
    labelChooser: LabelChooserReducer,
    addComment: AddACommentReducer,
    ticket: TicketDetailReducer,
});

export default rootReducer;
//@flow
import { ChangeComponentTextValue } from 'actions';
import type { ChangeComponentTextValueAction } from 'actions';
import { buildObjectReducer } from 'util/redux/ReducerBuilder';
import getComponentId from 'util/redux/getComponentId';
import type { AddACommentState } from './AddACommentState';

const defaultState = {
    commentBody: '',
    showSuccessMessage: false,
    showInvalidCommentMessage: false,
};

function getDefaultState(s : ?AddACommentState) : AddACommentState {
    return s || {...defaultState, componentId: getComponentId()};
}

const reducer = buildObjectReducer<AddACommentState>(getDefaultState)
    .filterByComponentId()
    .forTypeKey(ChangeComponentTextValue).andAction<ChangeComponentTextValueAction>((s, a) => {
        s = getDefaultState(s);
        return {...s, commentBody: a.payload.value};
    })
    .build();

export default reducer;
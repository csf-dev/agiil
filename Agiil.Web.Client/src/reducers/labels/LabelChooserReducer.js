//@flow
import type { LabelChooserState } from 'components/labels/LabelChooser';
import { ChangeSuggestionVisibility, ChangeSuggestionLoadingState, ReplaceSuggestions } from 'components/labels/LabelChooser';
import type { ChangeSuggestionVisibilityAction, ChangeSuggestionLoadingStateAction, ReplaceSuggestionsAction } from 'components/labels/LabelChooser';
import { ChangeComponentTextValue } from 'actions';
import type { ChangeComponentTextValueAction } from 'actions';
import { buildObjectReducer } from 'util/redux/ReducerBuilder';
import labelListReducer from './LabelListReducer';
import getComponentId from 'util/redux/getComponentId';
import type { Reducer } from 'redux';
import type { AnyAction } from 'models';

const defaultState = {
    value: '',
    showSuggestions: false,
    selectedLabels: undefined,
    suggestions: undefined,
    suggestionsLoading: false,
    ineligibleForSuggestions: true,
};
function getDefaultState(s : ?LabelChooserState) : LabelChooserState {
    return s || {...defaultState, componentId: getComponentId()};
}

const reducer : Reducer<LabelChooserState,AnyAction> = buildObjectReducer<LabelChooserState>(getDefaultState)
    .filterByComponentId()
    .forTypeKey(ChangeComponentTextValue).andAction<ChangeComponentTextValueAction>((s, a) => {
        s = getDefaultState(s);
        return {...s, value: a.payload.value, ineligibleForSuggestions: !a.payload.value};
    })
    .forTypeKey(ChangeSuggestionVisibility).andAction<ChangeSuggestionVisibilityAction>((s, a) => {
        s = getDefaultState(s);
        return {...s, showSuggestions: a.payload.showSuggestions};
    })
    .forTypeKey(ChangeSuggestionLoadingState).andAction<ChangeSuggestionLoadingStateAction>((s, a) => {
        s = getDefaultState(s);
        return {...s, suggestionsLoading: a.payload.loading};
    })
    .forTypeKey(ReplaceSuggestions).andAction<ReplaceSuggestionsAction>((s, a) => {
        s = getDefaultState(s);
        return {...s, suggestions: {...s.suggestions, labels: a.payload.suggestions}};
    })
    .forChild('selectedLabels').andReducer(labelListReducer)
    .forChild('suggestions').andReducer(labelListReducer)
    .build();

export default reducer;
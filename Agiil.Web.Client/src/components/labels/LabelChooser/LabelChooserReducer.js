//@flow
import type { LabelChooserState } from './LabelChooserState';
import { ChangeValue, ChangeSuggestionVisibility, ChangeSuggestionLoadingState, ReplaceSuggestions } from './LabelChooserActions';
import type { ChangeValueAction, ChangeSuggestionVisibilityAction, ChangeSuggestionLoadingStateAction, ReplaceSuggestionsAction } from './LabelChooserActions';
import { buildObjectReducer } from 'util/redux/ReducerBuilder';
import { labelListReducer } from '../LabelList';
import getComponentId from 'util/redux/getComponentId';

const defaultState = {
    value: '',
    showSuggestions: false,
    selectedLabels: undefined,
    suggestions: undefined,
    suggestionsLoading: false,
    ineligibleForSuggestions: true,
};
function getDefaultState(s : ?LabelChooserState) : LabelChooserState {
    if(!s) return {...defaultState, componentId: getComponentId()};
    if(!s.componentId) s.componentId = getComponentId();
    return s;
}

const reducer = buildObjectReducer<LabelChooserState>(getDefaultState)
    .filterByComponentId()
    .forTypeKey(ChangeValue).andAction<ChangeValueAction>((s, a) => {
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
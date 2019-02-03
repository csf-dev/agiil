//@flow
import type { LabelChooserState } from '../../domain/Labels/LabelChooserState';
import { ChangeValue, ChangeSuggestionVisibility, ChangeSuggestionLoadingState, ReplaceSuggestions } from './LabelChooserActions';
import type { ChangeValueAction, ChangeSuggestionVisibilityAction, ChangeSuggestionLoadingStateAction, ReplaceSuggestionsAction } from './LabelChooserActions';
import { buildObjectReducer } from '../../util/redux/ReducerBuilder';
import selectedLabelsReducer from './selectedLabelsReducer';
import getComponentId from '../../util/redux/getComponentId';

const defaultState = { value: '', showSuggestions: false, selectedLabels: undefined, suggestions: undefined, suggestionsLoading: false };
const getDefaultState = (s : ?LabelChooserState) => s || ({...defaultState, componentId : getComponentId()} : LabelChooserState);

const reducer = buildObjectReducer<LabelChooserState>(getDefaultState)
    .filterByComponentId()
    .forTypeKey(ChangeValue).andAction<ChangeValueAction>((s, a) => {
        s = getDefaultState(s);
        return {...s, value: a.payload.value};
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
    .forChild('selectedLabels').andReducer(selectedLabelsReducer)
    .forChild('suggestions').andReducer(selectedLabelsReducer)
    .build();

export default reducer;
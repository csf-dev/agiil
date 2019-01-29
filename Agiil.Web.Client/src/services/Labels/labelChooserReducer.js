//@flow
import type { LabelChooserState } from '../../domain/Labels/LabelChooserState';
import { ChangeValue, ChangeSuggestionVisibility } from './LabelChooserActions';
import type { ChangeValueAction, ChangeSuggestionVisibilityAction } from './LabelChooserActions';
import { buildObjectReducer } from '../../util/redux/ReducerBuilder';
import selectedLabelsReducer from './selectedLabelsReducer';

const defaultState = { value: '', showSuggestions: false, selectedLabels: [], suggestions: [] };

const reducer = buildObjectReducer<LabelChooserState>(defaultState)
    .forTypeKey(ChangeValue).andAction<ChangeValueAction>((s, a) => {
        if(s !== a.chooser) return s || defaultState;
        return {...s, value: a.value};
    })
    .forTypeKey(ChangeSuggestionVisibility).andAction<ChangeSuggestionVisibilityAction>((s, a) => {
        if(s !== a.chooser) return s || defaultState;
        return {...s, showSuggestions: a.showSuggestions};
    })
    .forChild('selectedLabels').andReducer(selectedLabelsReducer)
    .forChild('suggestions').andReducer(selectedLabelsReducer)
    .build();

export default reducer;
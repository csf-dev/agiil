//@flow
import type { LabelChooserState } from '../../domain/Labels/LabelChooserState';
import { ChangeValue, ChangeSuggestionVisibility } from './LabelChooserActions';
import type { ChangeValueAction, ChangeSuggestionVisibilityAction } from './LabelChooserActions';
import { buildObjectReducer } from '../../util/redux/ReducerBuilder';
import selectedLabelsReducer from './selectedLabelsReducer';
import getComponentId from '../../util/redux/componentId';

const defaultState = { value: '', showSuggestions: false, selectedLabels: undefined, suggestions: undefined };
const getDefaultState = (s : ?LabelChooserState) => s || ({...defaultState, id : getComponentId()} : LabelChooserState);

const reducer = buildObjectReducer<LabelChooserState>(getDefaultState)
    .forTypeKey(ChangeValue).andAction<ChangeValueAction>((s, a) => {
        s = getDefaultState(s);
        if(s.id !== a.meta?.id) return s;
        return {...s, value: a.payload.value};
    })
    .forTypeKey(ChangeSuggestionVisibility).andAction<ChangeSuggestionVisibilityAction>((s, a) => {
        s = getDefaultState(s);
        if(s.id !== a.meta?.id) return s;
        return {...s, showSuggestions: a.payload.showSuggestions};
    })
    .forChild('selectedLabels').andReducer(selectedLabelsReducer)
    .forChild('suggestions').andReducer(selectedLabelsReducer)
    .build();

export default reducer;
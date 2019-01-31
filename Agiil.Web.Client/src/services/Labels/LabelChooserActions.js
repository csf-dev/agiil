//@flow
import type { Action, ComponentId } from '../../Action';
import type { LabelChooserState } from '../../domain/Labels/LabelChooserState';
import type { SelectableLabel } from '../../domain/Labels/Label';

export const
    ChangeValue : 'CHANGE_VALUE' = 'CHANGE_VALUE',
    ChangeSuggestionVisibility : 'CHANGE_VISIBILITY' = 'CHANGE_VISIBILITY',
    ChangeSuggestionLoadingState : 'CHANGE_SUGGESTION_LOADING_STATE' = 'CHANGE_SUGGESTION_LOADING_STATE',
    ReplaceSuggestions : 'REPLACE_SUGGESTIONS' = 'REPLACE_SUGGESTIONS';

export type ChangeValueAction = Action<typeof ChangeValue,{value: string},ComponentId>;
export type ChangeSuggestionVisibilityAction = Action<typeof ChangeSuggestionVisibility,{showSuggestions : bool},ComponentId>;
export type ChangeSuggestionLoadingStateAction = Action<typeof ChangeSuggestionLoadingState,{loading: bool},ComponentId>;
export type ReplaceSuggestionsAction = Action<typeof ReplaceSuggestions,{suggestions : Array<SelectableLabel>},ComponentId>;

export function updateValue(value : string, id : string) : ChangeValueAction {
    return { type: ChangeValue, payload: { value }, meta: { id } };
}

export function changeVisibility(showSuggestions : bool, id : string) : ChangeSuggestionVisibilityAction {
    return { type: ChangeSuggestionVisibility, payload: { showSuggestions }, meta: { id } };
}

export function changeSuggestionLoading(loading : bool, id : string) : ChangeSuggestionLoadingStateAction {
    return { type: ChangeSuggestionLoadingState, payload: { loading }, meta: { id } };
}

export function replaceSuggestions(suggestions : Array<SelectableLabel>, id : string) : ReplaceSuggestionsAction {
    return { type: ReplaceSuggestions, payload: { suggestions }, meta: { id } };
}

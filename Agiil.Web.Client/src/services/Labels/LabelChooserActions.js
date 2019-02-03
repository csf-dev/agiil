//@flow
import type { Action, ComponentId } from '../../Action';
import type { LabelChooserState } from '../../domain/Labels/LabelChooserState';
import type { Label, SelectableLabel } from '../../domain/Labels/Label';
import { RequestsDataAsync } from '../../GetsDataAsync';

export function getDataService() : RequestsDataAsync<string,Array<Label>> {
    return {
        getDataAsync(request : string) : Promise<Array<Label>> {
            return Promise.resolve([{name: 'Three'}, {name: 'Four'}, {name: 'Five'}]);
        }
    }
}

export const
    ChangeValue : 'CHANGE_VALUE' = 'CHANGE_VALUE',
    ChangeSuggestionVisibility : 'CHANGE_VISIBILITY' = 'CHANGE_VISIBILITY',
    ChangeSuggestionLoadingState : 'CHANGE_SUGGESTION_LOADING_STATE' = 'CHANGE_SUGGESTION_LOADING_STATE',
    ReplaceSuggestions : 'REPLACE_SUGGESTIONS' = 'REPLACE_SUGGESTIONS';

export type ChangeValueAction = Action<typeof ChangeValue,{value: string},ComponentId>;
export type ChangeSuggestionVisibilityAction = Action<typeof ChangeSuggestionVisibility,{showSuggestions : bool},ComponentId>;
export type ChangeSuggestionLoadingStateAction = Action<typeof ChangeSuggestionLoadingState,{loading: bool},ComponentId>;
export type ReplaceSuggestionsAction = Action<typeof ReplaceSuggestions,{suggestions : Array<SelectableLabel>},ComponentId>;

export function updateValue(value : string, componentId : string) : ChangeValueAction {
    return { type: ChangeValue, payload: { value }, meta: { componentId } };
}

export function changeVisibility(showSuggestions : bool, componentId : string) : ChangeSuggestionVisibilityAction {
    return { type: ChangeSuggestionVisibility, payload: { showSuggestions }, meta: { componentId } };
}

export function changeSuggestionLoading(loading : bool, componentId : string) : ChangeSuggestionLoadingStateAction {
    return { type: ChangeSuggestionLoadingState, payload: { loading }, meta: { componentId } };
}

export function replaceSuggestions(suggestions : Array<SelectableLabel>, componentId : string) : ReplaceSuggestionsAction {
    return { type: ReplaceSuggestions, payload: { suggestions }, meta: { componentId } };
}

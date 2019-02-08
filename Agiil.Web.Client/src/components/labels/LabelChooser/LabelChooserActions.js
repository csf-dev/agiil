//@flow
import type { Action, AnyAction, ComponentId } from 'models';
import type { LabelChooserState } from './LabelChooserState';
import type { Label, SelectableLabel } from 'models/labels';
import { RequestsDataAsync } from 'services';
import getLabelSuggester from 'services/labels/LabelSuggester';
import type { Dispatch } from 'redux';

export const
    ChangeValue : 'CHANGE_VALUE' = 'CHANGE_VALUE',
    ChangeSuggestionVisibility : 'CHANGE_VISIBILITY' = 'CHANGE_VISIBILITY',
    ChangeSuggestionLoadingState : 'CHANGE_SUGGESTION_LOADING_STATE' = 'CHANGE_SUGGESTION_LOADING_STATE',
    ReplaceSuggestions : 'REPLACE_SUGGESTIONS' = 'REPLACE_SUGGESTIONS';

export type ChangeValueAction = Action<typeof ChangeValue,{value: string},ComponentId>;
export type ChangeSuggestionVisibilityAction = Action<typeof ChangeSuggestionVisibility,{showSuggestions : bool},ComponentId>;
export type ChangeSuggestionLoadingStateAction = Action<typeof ChangeSuggestionLoadingState,{loading: bool},ComponentId>;
export type ReplaceSuggestionsAction = Action<typeof ReplaceSuggestions,{suggestions : Array<SelectableLabel>},ComponentId>;

export function updateValue(value : string, componentId : string, labelSuggester? : RequestsDataAsync<string,Array<Label>>) : (d : Dispatch<AnyAction>) => Promise<void> {
    const suggester : RequestsDataAsync<string,Array<Label>> = labelSuggester || getLabelSuggester();

    return async (dispatch : Dispatch<AnyAction>) => {
        dispatch({ type: ChangeValue, payload: { value }, meta: { componentId } });
        
        if(value.trim() === '')
        {
            dispatch(replaceSuggestions([], componentId));
            dispatch(changeSuggestionLoading(false, componentId));
            return;
        }

        dispatch(changeSuggestionLoading(true, componentId));

        const suggestions = await suggester.getDataAsync(value);

        dispatch(replaceSuggestions(suggestions.map(x => ({...x, selected: false})), componentId));
        dispatch(changeSuggestionLoading(false, componentId));
    };


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

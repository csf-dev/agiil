//@flow
import type { Action, AnyAction, ComponentId } from 'models';
import type { LabelChooserState } from './LabelChooserState';
import type { Label, SelectableLabel } from 'models/labels';
import { RequestsDataAsync } from 'services';
import getLabelSuggester from 'services/labels/LabelSuggester';
import type { Dispatch } from 'redux';
import type { Cancelable } from 'models';
import { Subject } from 'rxjs';
import { debounceInput } from 'services/common';
import { ChangeComponentTextValue } from 'actions';

export const
    ChangeSuggestionVisibility : 'CHANGE_VISIBILITY' = 'CHANGE_VISIBILITY',
    ChangeSuggestionLoadingState : 'CHANGE_SUGGESTION_LOADING_STATE' = 'CHANGE_SUGGESTION_LOADING_STATE',
    ReplaceSuggestions : 'REPLACE_SUGGESTIONS' = 'REPLACE_SUGGESTIONS';

export type ChangeSuggestionVisibilityAction = Action<typeof ChangeSuggestionVisibility,{showSuggestions : bool},ComponentId>;
export type ChangeSuggestionLoadingStateAction = Action<typeof ChangeSuggestionLoadingState,{loading: bool},ComponentId>;
export type ReplaceSuggestionsAction = Action<typeof ReplaceSuggestions,{suggestions : Array<SelectableLabel>},ComponentId>;

type ValueStream = {
    value: string;
    dispatch: Dispatch<AnyAction>;
    componentId : string;
    suggester : RequestsDataAsync<string,Array<Label>>;
};

const pendingRequests = new Map<string,Cancelable<Array<Label>>>();
const inputStream = new Subject<ValueStream>();

export function updateValue(value : string, componentId : string, labelSuggester? : RequestsDataAsync<string,Array<Label>>) : (d : Dispatch<AnyAction>) => void {
    const suggester : RequestsDataAsync<string,Array<Label>> = labelSuggester || getLabelSuggester();

    return (dispatch : Dispatch<AnyAction>) => {
        dispatch({ type: ChangeComponentTextValue, payload: { value }, meta: { componentId } });
        inputStream.next({value, dispatch, componentId, suggester});
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

inputStream.subscribe((next : ValueStream) => {
    if(valueIsEmpty(next.value))
    {
        handleEmptyValue(next);
        return;
    }

    next.dispatch(changeSuggestionLoading(true, next.componentId));
});

const debouncedStream = inputStream.pipe(debounceInput<ValueStream>());
debouncedStream.subscribe((next : ValueStream) => {
    if(valueIsEmpty(next.value)) return;

    clearPendingRequests();

    const pendingRequest = next.suggester.getDataAsync(next.value);
    pendingRequests.set(pendingRequest.id, pendingRequest);

    pendingRequest.promise.then(res => {
        next.dispatch(replaceSuggestions(res.map(x => ({...x, selected: false})), next.componentId));
        next.dispatch(changeSuggestionLoading(false, next.componentId));
        pendingRequests.delete(pendingRequest.id);
    });
});

function valueIsEmpty(value) { return !value || value.trim() === ''; }

function handleEmptyValue(item : ValueStream) {
    clearPendingRequests();
    item.dispatch(replaceSuggestions([], item.componentId));
    item.dispatch(changeSuggestionLoading(false, item.componentId));
}

function clearPendingRequests() {
    pendingRequests.forEach(req => req.cancel());
    pendingRequests.clear();
}
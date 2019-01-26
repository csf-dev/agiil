//@flow
import type { Action } from '../Action';
import type { SelectableLabel } from './Label';

export const
    AddLabel = 'ADD_LABEL',
    RemoveLabel = 'REMOVE_LABEL',
    NavigateSuggestion = 'NAVIGATE_SUGGESTION';
export type SelectedLabelsAction = Action & { add? : SelectableLabel, remove? : SelectableLabel };

export function addLabel(add : SelectableLabel) : SelectedLabelsAction {
    return { type: AddLabel, add };
}

export function removeLabel(remove : SelectableLabel) : SelectedLabelsAction {
    return { type: RemoveLabel, remove };
}

export function nextSuggestion() {
    return { type: NavigateSuggestion, dir: 1 };
}

export function prevSuggestion() {
    return { type: NavigateSuggestion, dir: -1 };
}
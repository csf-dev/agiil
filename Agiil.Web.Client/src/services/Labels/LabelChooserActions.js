//@flow
import type { Action } from '../../Action';
import type { LabelChooserState } from '../../domain/Labels/LabelChooserState';

export const
    ChangeValue : 'CHANGE_VALUE' = 'CHANGE_VALUE',
    ChangeSuggestionVisibility : 'CHANGE_VISIBILITY' = 'CHANGE_VISIBILITY';

export type ChangeValueAction = Action<typeof ChangeValue> & {
    chooser : LabelChooserState,
    value: string,
}

export type ChangeSuggestionVisibilityAction = Action<typeof ChangeSuggestionVisibility> & {
    chooser : LabelChooserState,
    showSuggestions : bool,
}

export function updateValue(value : string, chooser : LabelChooserState) : ChangeValueAction {
    return { type: ChangeValue, chooser, value };
}

export function changeVisibility(value : bool, chooser : LabelChooserState) : ChangeSuggestionVisibilityAction {
    return { type: ChangeSuggestionVisibility, chooser, showSuggestions: value };
}

//@flow
import type { Action } from '../Action';
import type { RemovableLabel } from './Label';

export const AddLabel = 'ADD_LABEL', RemoveLabel = 'REMOVE_LABEL';
export type SelectedLabelsAction = Action & { add? : RemovableLabel, remove? : RemovableLabel };

export function addLabel(add : RemovableLabel) : SelectedLabelsAction {
    return { type: AddLabel, add };
}

export function removeLabel(remove : RemovableLabel) : SelectedLabelsAction {
    return { type: RemoveLabel, remove };
}
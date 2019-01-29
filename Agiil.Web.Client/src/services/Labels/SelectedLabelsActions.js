//@flow
import type { Action } from '../../Action';
import type { SelectableLabel } from '../../domain/Labels/Label';

export const
    AddLabel = 'ADD_LABEL',
    RemoveLabel = 'REMOVE_LABEL',
    SelectLabel = 'SELECT_LABEL',
    NavigateSelection = 'NAVIGATE_SELECTION',
    DeselectAll = 'DESELECT_ALL';

export type AddLabelAction = Action<typeof AddLabel> & { label : SelectableLabel, list : Array<SelectableLabel> };
export type RemoveLabelAction = Action<typeof RemoveLabel> & { label : SelectableLabel, list : Array<SelectableLabel> };
export type SelectLabelAction = Action<typeof SelectLabel> & { label : SelectableLabel, list : Array<SelectableLabel> };
export type NavigateSelectionAction = Action<typeof NavigateSelection> & { dir : number, list : Array<SelectableLabel> };
export type DeselectAllAction = Action<typeof DeselectAll> & { list : Array<SelectableLabel> };


export function addLabel(list: Array<SelectableLabel>, label : SelectableLabel) : AddLabelAction {
    return { type: AddLabel, label, list };
}

export function removeLabel(list: Array<SelectableLabel>, label : SelectableLabel) : RemoveLabelAction {
    return { type: RemoveLabel, label, list };
}

export function selectLabel(list: Array<SelectableLabel>, label : SelectableLabel) : SelectLabelAction {
    return { type: SelectLabel, label, list };
}
export function selectNext(list: Array<SelectableLabel>) : NavigateSelectionAction {
    return { type: NavigateSelection, dir: 1, list };
}

export function selectPrev(list: Array<SelectableLabel>) : NavigateSelectionAction {
    return { type: NavigateSelection, dir: -1, list };
}

export function deselectAll(list: Array<SelectableLabel>) : DeselectAllAction {
    return { type: DeselectAll, list };
}

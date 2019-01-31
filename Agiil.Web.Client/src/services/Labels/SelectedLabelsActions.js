//@flow
import type { Action, ComponentId } from '../../Action';
import type { SelectableLabel } from '../../domain/Labels/Label';

export const
    AddLabel = 'ADD_LABEL',
    RemoveLabel = 'REMOVE_LABEL',
    SelectLabel = 'SELECT_LABEL',
    NavigateSelection = 'NAVIGATE_SELECTION',
    DeselectAll = 'DESELECT_ALL';

export type AddLabelAction = Action<typeof AddLabel,{label : SelectableLabel},ComponentId>;
export type RemoveLabelAction = Action<typeof RemoveLabel,{label : SelectableLabel},ComponentId>;
export type SelectLabelAction = Action<typeof SelectLabel,{label : SelectableLabel},ComponentId>;
export type NavigateSelectionAction = Action<typeof NavigateSelection,{ dir : number },ComponentId>;
export type DeselectAllAction = Action<typeof DeselectAll,void,ComponentId>;


export function addLabel(label : SelectableLabel, id : string) : AddLabelAction {
    return { type: AddLabel, payload: { label }, meta: { id } };
}

export function removeLabel(label : SelectableLabel, id : string) : RemoveLabelAction {
    return { type: RemoveLabel, payload: { label }, meta: { id } };
}

export function selectLabel(label : SelectableLabel, id : string) : SelectLabelAction {
    return { type: SelectLabel, payload: { label }, meta: { id } };
}
export function selectNext(id : string) : NavigateSelectionAction {
    return { type: NavigateSelection, payload: { dir: 1 }, meta: { id } };
}

export function selectPrev(id : string) : NavigateSelectionAction {
    return { type: NavigateSelection, payload: { dir: 1 }, meta: { id } };
}

export function deselectAll(id : string) : DeselectAllAction {
    return { type: DeselectAll, payload: undefined, meta: { id } };
}

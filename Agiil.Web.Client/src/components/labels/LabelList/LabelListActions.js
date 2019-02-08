//@flow
import type { Action, ComponentId } from 'models';
import type { SelectableLabel } from 'models/labels';

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


export function addLabel(label : SelectableLabel, componentId : string) : AddLabelAction {
    return { type: AddLabel, payload: { label }, meta: { componentId } };
}

export function removeLabel(label : SelectableLabel, componentId : string) : RemoveLabelAction {
    return { type: RemoveLabel, payload: { label }, meta: { componentId } };
}

export function selectLabel(label : SelectableLabel, componentId : string) : SelectLabelAction {
    return { type: SelectLabel, payload: { label }, meta: { componentId } };
}
export function selectNext(componentId : string) : NavigateSelectionAction {
    return { type: NavigateSelection, payload: { dir: 1 }, meta: { componentId } };
}

export function selectPrev(componentId : string) : NavigateSelectionAction {
    return { type: NavigateSelection, payload: { dir: -1 }, meta: { componentId } };
}

export function deselectAll(componentId : string) : DeselectAllAction {
    return { type: DeselectAll, payload: undefined, meta: { componentId } };
}

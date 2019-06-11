//@flow
import type { SelectableLabel } from 'models/labels';
import { AddLabel, RemoveLabel, SelectLabel, NavigateSelection, DeselectAll } from 'components/labels/LabelList';
import type { AddLabelAction, RemoveLabelAction, SelectLabelAction, NavigateSelectionAction, DeselectAllAction } from 'components/labels/LabelList';
import { buildObjectReducer } from 'util/redux/ReducerBuilder';
import type { LabelListState } from 'components/labels/LabelList';
import getComponentId from 'util/redux/getComponentId';

const defaultState = { labels: [] };
const getDefaultState = (s : ?LabelListState) => s || ({...defaultState, componentId : getComponentId()} : LabelListState);

const reducer = buildObjectReducer<LabelListState>(getDefaultState)
    .filterByComponentId()
    .forTypeKey(AddLabel).andAction<AddLabelAction>((s, a) => {
        s = getDefaultState(s);
        const out = cloneState(s);
        out.labels.push(a.payload.label);
        return out;
    })
    .forTypeKey(RemoveLabel).andAction<RemoveLabelAction>((s, a) => {
        s = getDefaultState(s);
        const out = cloneState(s);
        out.labels = out.labels.filter(x => x.name !== a.payload.label.name);
        return out;
    })
    .forTypeKey(SelectLabel).andAction<SelectLabelAction>((s, a) => {
        s = getDefaultState(s);
        const out = cloneState(s);
        deselectAll(out.labels);
        const label = out.labels.find(x => x.name === a.payload.label.name);
        if(label) label.selected = true;
        return out;
    })
    .forTypeKey(NavigateSelection).andAction<NavigateSelectionAction>((s, a) => {
        s = getDefaultState(s);
        const out = cloneState(s);
        if(a.payload.dir) {
            const
                selectedIndex = out.labels.findIndex(x => x.selected),
                newIndex = selectedIndex + a.payload.dir;
            
            if(newIndex >= 0 && newIndex < out.labels.length) {
                deselectAll(out.labels);
                out.labels[newIndex].selected = true;
            }
            else if(newIndex < 0) {
                deselectAll(out.labels);
            }
        }
        return out;
    })
    .forTypeKey(DeselectAll).andAction<DeselectAllAction>((s, a) => {
        s = getDefaultState(s);
        const out = cloneState(s);
        deselectAll(out.labels);
        return out;
    })
    .build();

function cloneState(s : LabelListState) : LabelListState {
    return { componentId: s.componentId, labels: (s.labels? [...s.labels] : []) };
}

function deselectAll(labels : Array<SelectableLabel>) {
    labels.forEach(x => x.selected = false);
}

export default reducer;
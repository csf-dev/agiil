//@flow
import type { SelectableLabel } from '../../domain/Labels/Label';
import { AddLabel, RemoveLabel, SelectLabel, NavigateSelection, DeselectAll } from './SelectedLabelsActions';
import type { AddLabelAction, RemoveLabelAction, SelectLabelAction, NavigateSelectionAction, DeselectAllAction } from './SelectedLabelsActions';
import { buildPrimitiveReducer } from '../../util/redux/ReducerBuilder';

const reducer = buildPrimitiveReducer<Array<SelectableLabel>>([])
    .forTypeKey(AddLabel).andAction<AddLabelAction>((s, a) => {
        if(s !== a.list) return s || [];

        const out = cloneState(s);
        out.push(a.label);
        return out;
    })
    .forTypeKey(RemoveLabel).andAction<RemoveLabelAction>((s, a) => {
        if(s !== a.list) return s || [];
        
        const out = cloneState(s);
        return out.filter(x => x.name !== a.label.name);
    })
    .forTypeKey(SelectLabel).andAction<SelectLabelAction>((s, a) => {
        if(s !== a.list) return s || [];
        
        const out = cloneState(s);
        deselectAll(out);
        const label = out.find(x => x.name === a.label.name);
        if(label) label.selected = true;
        return out;
    })
    .forTypeKey(NavigateSelection).andAction<NavigateSelectionAction>((s, a) => {
        if(s !== a.list) return s || [];
        
        const out = cloneState(s);
        if(a.dir) {
            const
                selectedIndex = out.findIndex(x => x.selected),
                newIndex = selectedIndex + a.dir;
            
            if(newIndex >= 0 && newIndex < out.length) {
                deselectAll(out);
                out[newIndex].selected = true;
            }
        }
        return out;
    })
    .forTypeKey(DeselectAll).andAction<DeselectAllAction>((s, a) => {
        if(s !== a.list) return s || [];
        
        const out = cloneState(s);
        deselectAll(out);
        return out;
    })
    .build();

function cloneState(s : ?Array<SelectableLabel>) : Array<SelectableLabel> {
    return (s? [...s] : []);
}

function deselectAll(labels : Array<SelectableLabel>) {
    labels.forEach(x => x.selected = false);
}

export default reducer;
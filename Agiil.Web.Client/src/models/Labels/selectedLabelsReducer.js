//@flow
import type { RemovableLabel } from './Label';
import type { SelectedLabelsAction } from './SelectedLabelsActions';
import { AddLabel, RemoveLabel } from './SelectedLabelsActions';

function selectedLabelsReducer(state : Array<RemovableLabel> = [], action : SelectedLabelsAction) {
    let newState : Array<RemovableLabel> = state.slice();

    switch(action.type) {
    case AddLabel:
        if(action.add) newState.push(action.add);
        break;
    
    case RemoveLabel:
        if(action.remove) {
            const toRemove = action.remove;
            newState = newState.filter(x => x.name !== toRemove.name);
        }
        break;
    }

    return newState;
}
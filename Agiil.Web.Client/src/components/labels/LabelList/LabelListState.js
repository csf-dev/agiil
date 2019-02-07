//@flow
import type { SelectableLabel } from 'models/labels';
import type { ComponentId } from 'Action';

export type LabelListState = ComponentId & {
    labels : Array<SelectableLabel>;
};

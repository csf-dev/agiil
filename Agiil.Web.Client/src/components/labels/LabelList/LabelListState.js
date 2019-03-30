//@flow
import type { SelectableLabel } from 'models/labels';
import type { ComponentId } from 'models';

export type LabelListState = ComponentId & {
    labels : Array<SelectableLabel>;
};

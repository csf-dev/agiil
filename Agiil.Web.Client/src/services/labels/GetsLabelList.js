//@flow
import type { SelectableLabel } from 'models/labels';

export interface GetsLabelList {
    getLabelList() : Array<SelectableLabel>;
};
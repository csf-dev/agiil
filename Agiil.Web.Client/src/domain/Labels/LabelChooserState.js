//@flow
import type { SelectableLabel } from './Label';

export type LabelChooserState = {
    value: string;
    showSuggestions : bool;
    selectedLabels : Array<SelectableLabel>;
    suggestions : Array<SelectableLabel>;
}
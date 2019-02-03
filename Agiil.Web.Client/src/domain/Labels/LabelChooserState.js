//@flow
import type { SelectableLabel } from './Label';
import type { ComponentId } from '../../Action';

export type SelectableLabelList = ComponentId & {
    labels : Array<SelectableLabel>;
};

export type LabelChooserState = ComponentId & {
    value: string;
    showSuggestions : bool;
    selectedLabels : SelectableLabelList;
    suggestionsLoading : bool;
    suggestions : SelectableLabelList;
}
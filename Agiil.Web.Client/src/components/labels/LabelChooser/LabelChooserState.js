//@flow
import type { SelectableLabel } from 'models/labels';
import type { ComponentId } from 'Action';
import type { LabelListState } from 'components/labels/LabelList';

export type LabelChooserState = ComponentId & {
    value: string;
    showSuggestions : bool;
    selectedLabels : LabelListState;
    suggestionsLoading : bool;
    suggestions : LabelListState;
}
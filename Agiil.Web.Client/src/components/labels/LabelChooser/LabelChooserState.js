//@flow
import type { SelectableLabel } from 'models/labels';
import type { ComponentId } from 'models';
import type { LabelListState } from 'components/labels/LabelList';

export type LabelChooserState = ComponentId & {
    selectedLabels : LabelListState;
    suggestions : LabelListState;
    value: string;
    showSuggestions : bool;
    suggestionsLoading : bool;
    ineligibleForSuggestions : bool;
}
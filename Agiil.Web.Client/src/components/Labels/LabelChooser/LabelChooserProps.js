//@flow
import type { Label, SelectableLabel } from '../../../domain/Labels/Label';
import { RequestsDataAsync } from '../../../domain/GetsDataAsync';

export type LabelChooserProps = {
    labels : Array<SelectableLabel>,
    id? : string,
    suggestions?: Array<SelectableLabel>,
    labelSuggester? : RequestsDataAsync<string,Array<Label>>,
    inputValue? : string,
    uiLabelText? : string,
    showSuggestions? : bool,
    noSuggestionsLoaded : bool,
    suggestionsLoading : bool,
    onAdd : (label : Label) => void,
    onRemove : (label : SelectableLabel) => void,
    onSelectForRemoval : (label : SelectableLabel) => void,
    onDeselectForRemoval : (label : SelectableLabel) => void,
    onInputValueChanged : (value : string) => void,
    onShowSuggestionsChanged : (value : bool) => void,
    onSelectNextSuggestion : () => void,
    onSelectPrevSuggestion : () => void,
    onResetSelectedSuggestion : () => void,
    onClickSuggestion: (label : SelectableLabel) => void
};

//@flow
import type { Label, SelectableLabel } from '../../../domain/Labels/Label';
import { RequestsDataAsync } from '../../../GetsDataAsync';

export type LabelChooserProps = {
    labels : Array<SelectableLabel>,
    id? : string,
    suggestions?: Array<SelectableLabel>,
    inputValue? : string,
    uiLabelText? : string,
    showSuggestions? : bool,
    noSuggestionsLoaded : bool,
    suggestionsLoading : bool,
    componentId : string,
    selectedLabelsComponentId : string,
    suggestionsComponentId : string,
    labelSuggester : ?RequestsDataAsync<string,Array<Label>>,
    onAdd : (label : Label, componentId : string) => void,
    onRemove : (label : SelectableLabel, componentId : string) => void,
    onSelectForRemoval : (label : SelectableLabel, componentId : string) => void,
    onDeselectForRemoval : (componentId : string) => void,
    onInputValueChanged : (value : string, componentId : string, labelSuggester : ?RequestsDataAsync<string,Array<Label>>) => void,
    onShowSuggestionsChanged : (value : bool, componentId : string) => void,
    onSelectNextSuggestion : (componentId : string) => void,
    onSelectPrevSuggestion : (componentId : string) => void,
    onResetSelectedSuggestion : (componentId : string) => void,
    onClickSuggestion: (label : SelectableLabel, componentId : string) => void
};

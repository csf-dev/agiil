//@flow
import type { Label, SelectableLabel } from '../../../domain/Labels/Label';

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
    onAdd : (label : Label, componentId : string) => void,
    onRemove : (label : SelectableLabel, componentId : string) => void,
    onSelectForRemoval : (label : SelectableLabel, componentId : string) => void,
    onDeselectForRemoval : (label : SelectableLabel, componentId : string) => void,
    onInputValueChanged : (value : string, componentId : string) => void,
    onShowSuggestionsChanged : (value : bool, componentId : string) => void,
    onSelectNextSuggestion : (componentId : string) => void,
    onSelectPrevSuggestion : (componentId : string) => void,
    onResetSelectedSuggestion : (componentId : string) => void,
    onClickSuggestion: (label : SelectableLabel, componentId : string) => void
};

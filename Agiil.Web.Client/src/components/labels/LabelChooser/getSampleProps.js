//@flow
import type { LabelChooserProps } from './LabelChooserProps';
import type { Label, SelectableLabel } from 'models/labels';

export function getSampleProps() : LabelChooserProps {
    return {
        labels : [{name:'One', selected: false}, {name:'Two', selected: true}],
        noSuggestionsLoaded : false,
        suggestionsLoading : false,
        componentId : 'ABC123',
        selectedLabelsComponentId : 'DEF456',
        suggestionsComponentId : 'GHI789',
        labelSuggester : null,
        onAdd : (label : Label) => {},
        onRemove : (label : SelectableLabel) => {},
        onSelectForRemoval : (label : SelectableLabel) => {},
        onDeselectForRemoval : () => {},
        onInputValueChanged : (value : string) => {},
        onShowSuggestionsChanged : (value : bool) => {},
        onSelectNextSuggestion : () => {},
        onSelectPrevSuggestion : () => {},
        onResetSelectedSuggestion : () => {},
        onClickSuggestion: (label : SelectableLabel) => {}
    };
}
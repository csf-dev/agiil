//@flow
import type { LabelChooserProps } from './LabelChooserProps';
import type { Label, SelectableLabel } from '../../../domain/Labels/Label';

export function getSampleProps() : LabelChooserProps {
    return {
        labels : [{name:'One', selected: false}, {name:'Two', selected: true}],
        noSuggestionsLoaded : false,
        suggestionsLoading : false,
        componentId : 'ABC123',
        selectedLabelsComponentId : 'DEF456',
        suggestionsComponentId : 'GHI789',
        onAdd : (label : Label) => {},
        onRemove : (label : SelectableLabel) => {},
        onSelectForRemoval : (label : SelectableLabel) => {},
        onDeselectForRemoval : (label : SelectableLabel) => {},
        onInputValueChanged : (value : string) => {},
        onShowSuggestionsChanged : (value : bool) => {},
        onSelectNextSuggestion : () => {},
        onSelectPrevSuggestion : () => {},
        onResetSelectedSuggestion : () => {},
        onClickSuggestion: (label : SelectableLabel) => {}
    };
}
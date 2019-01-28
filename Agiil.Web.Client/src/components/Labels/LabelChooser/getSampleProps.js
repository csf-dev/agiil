//@flow
import type { LabelChooserProps } from './LabelChooserProps';
import type { Label, SelectableLabel } from '../../../domain/Labels/Label';
import { RequestsDataAsync } from '../../../GetsDataAsync';

export function getDataService() : RequestsDataAsync<string,Array<Label>> {
    return {
        getDataAsync(request : string) : Promise<Array<Label>> {
            return Promise.resolve([{name: 'Three'}, {name: 'Four'}, {name: 'Five'}]);
        }
    }
}

export function getSampleProps() : LabelChooserProps {
    return {
        labels : [{name:'One', selected: false}, {name:'Two', selected: true}],
        labelSuggester : getDataService(),
        noSuggestionsLoaded : false,
        suggestionsLoading : false,
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
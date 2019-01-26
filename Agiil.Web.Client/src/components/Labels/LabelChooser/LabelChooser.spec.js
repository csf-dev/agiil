//@flow
import LabelChooser from './LabelChooser';
import type { LabelChooserProps } from './LabelChooserProps';
import ReactDOM from 'react-dom';
import React from "react";
import type { Label, SelectableLabel } from '../../../domain/Labels/Label';
import { RequestsDataAsync } from '../../../domain/GetsDataAsync';
import { getTestDom } from '../../../util/TestDom';

describe('The label chooser', () => {
    it('should render without crashing', () => {
        const root = getTestDom();
        ReactDOM.render(<LabelChooser {...getMinimalProps()} />, root);
    });
});

function getDataService() : RequestsDataAsync<string,Array<Label>> {
    return {
        getDataAsync(request : string) : Promise<Array<Label>> {
            return Promise.resolve([{name: 'Three'}, {name: 'Four'}, {name: 'Five'}]);
        }
    }
}

function getMinimalProps() : LabelChooserProps {
    return {
        labels : [{name:'One', selected: false}, {name:'Two', selected: false}],
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
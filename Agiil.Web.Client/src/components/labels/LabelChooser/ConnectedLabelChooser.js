//@flow
import { connect } from 'react-redux';
import { LabelChooser } from './LabelChooser';
import type { LabelChooserProps } from './LabelChooserProps';
import type { LabelChooserState } from './LabelChooserState';
import type { Dispatch } from 'redux';
import type { AnyAction } from 'models';
import * as LabelList from 'components/labels/LabelList';
import * as ChooserActions from './LabelChooserActions';
import type { Label, SelectableLabel } from 'models/labels';
import { RequestsDataAsync } from 'services';

export type ConnectedLabelChooserProps = {|
    id? : string,
    labelText? : string,
    stateSelector : (store : any) => LabelChooserState,
    labelSuggester? : RequestsDataAsync<string,Array<Label>>
|};

type StatefulProps = {|
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
    labelSuggester : ?RequestsDataAsync<string,Array<Label>>
|};

function mapStateToProps(store : any, ownProps : ConnectedLabelChooserProps) : StatefulProps {
    const state = ownProps.stateSelector(store);
    return {
        labels: state.selectedLabels.labels,
        id: ownProps.id,
        suggestions: state.suggestions.labels,
        inputValue: state.value,
        uiLabelText: ownProps.labelText,
        showSuggestions: state.showSuggestions,
        noSuggestionsLoaded: state.ineligibleForSuggestions,
        suggestionsLoading: state.suggestionsLoading,
        componentId: state.componentId,
        selectedLabelsComponentId: state.selectedLabels.componentId,
        suggestionsComponentId: state.suggestions.componentId,
        labelSuggester: ownProps.labelSuggester
    };
}

const mapDispatchToProps = {
    onAdd: LabelList.addLabel,
    onRemove: LabelList.removeLabel,
    onSelectForRemoval: LabelList.selectLabel,
    onDeselectForRemoval: LabelList.deselectAll,
    onInputValueChanged: ChooserActions.updateValue,
    onShowSuggestionsChanged: ChooserActions.changeVisibility,
    onSelectNextSuggestion : LabelList.selectNext,
    onSelectPrevSuggestion : LabelList.selectPrev,
    onResetSelectedSuggestion : LabelList.deselectAll,
    onClickSuggestion: LabelList.addLabel
}

const connectedLabelChooser = connect<LabelChooserProps,ConnectedLabelChooserProps, any, any, any, any>(
    mapStateToProps,
    mapDispatchToProps
)(LabelChooser);
export default connectedLabelChooser;
//@flow
import { connect } from 'react-redux';
import LabelChooser from './LabelChooser';
import type { LabelChooserProps } from './LabelChooserProps';
import type { LabelChooserState } from '../../../domain/Labels/LabelChooserState';
import type { Dispatch } from 'redux';
import type { AnyAction } from '../../../Action';
import * as LabelActions from '../../../services/Labels/SelectedLabelsActions';
import * as ChooserActions from '../../../services/Labels/LabelChooserActions';
import type { Label, SelectableLabel } from '../../../domain/Labels/Label';

export type ConnectedLabelChooserProps = {|
    id? : string,
    labelText? : string,
    stateSelector : (store : any) => LabelChooserState,
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
        noSuggestionsLoaded: state.suggestions.labels.length === 0,
        suggestionsLoading: state.suggestionsLoading,
        componentId: state.componentId,
        selectedLabelsComponentId: state.selectedLabels.componentId,
        suggestionsComponentId: state.suggestions.componentId,
    };
}

const mapDispatchToProps = {
    onAdd: LabelActions.addLabel,
    onRemove: LabelActions.removeLabel,
    onSelectForRemoval: LabelActions.selectLabel,
    onDeselectForRemoval: LabelActions.deselectAll,
    onInputValueChanged: ChooserActions.updateValue,
    onShowSuggestionsChanged: ChooserActions.changeVisibility,
    onSelectNextSuggestion : LabelActions.selectNext,
    onSelectPrevSuggestion : LabelActions.selectPrev,
    onResetSelectedSuggestion : LabelActions.deselectAll,
    onClickSuggestion: LabelActions.addLabel
}

const connectedLabelChooser = connect<LabelChooserProps,ConnectedLabelChooserProps, any, any, any, any>(mapStateToProps, mapDispatchToProps)(LabelChooser);
export default connectedLabelChooser;
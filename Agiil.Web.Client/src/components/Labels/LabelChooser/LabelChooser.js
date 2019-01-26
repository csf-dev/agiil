//@flow
import * as React from "react";
import SelectedLabelList from './SelectedLabelList';
import LabelPicker from './LabelPicker';
import LabelSuggestions from './LabelSuggestions';
import getLabelSuggester from '../../../services/Labels/LabelSuggester';
import type { LabelChooserProps } from './LabelChooserProps';
import LabelChooserBehaviours from './LabelChooserBehaviours';
// $FlowFixMe
import styles from './LabelChooser.scss';

export default class LabelChooser extends React.Component<LabelChooserProps> {
    behaviours : LabelChooserBehaviours;

    render() {
        const inputId = getInputId(this.props);
        function onPickerKeypress(ev) { this.behaviours.onKeypress(ev); }
        function onPickerChange(ev) { this.behaviours.onChange(ev); }

        return (
            <div className={styles.LabelChooser} id={this.props.id}>
                { getInputLabel(this.props, inputId) }
                <SelectedLabelList
                    labels={this.props.labels}
                    onRemove={this.props.onRemove}
                    />
                <LabelPicker
                    onKeypress={onPickerKeypress.bind(this)}
                    onChange={onPickerChange.bind(this)}
                    inputValue={this.props.inputValue}
                    inputId={inputId}
                    onFocusChanged={this.props.onShowSuggestionsChanged}
                    />
                <LabelSuggestions 
                    suggestions={this.props.suggestions || []}
                    show={this.props.showSuggestions || false}
                    onClickSuggestion={this.props.onClickSuggestion}
                    noSuggestionsLoaded={this.props.noSuggestionsLoaded}
                    suggestionsLoading={this.props.suggestionsLoading}
                    />
            </div>
        );
    }

    constructor(props : LabelChooserProps) {
        super();

        const mergedProps = Object.assign({}, defaultProps, props);
        this.behaviours = new LabelChooserBehaviours(mergedProps);
    }
}

const defaultProps = { labelSuggester: getLabelSuggester() };

function getInputLabel(props : LabelChooserProps, inputId : ?string) {
    const hideInputLabel = !(props.uiLabelText && props.uiLabelText.length);
    if(hideInputLabel) return null;

    return <label for={inputId}>{props.uiLabelText}</label>;
}

function getInputId(props : LabelChooserProps) : ?string {
    if(!props.id) return null;
    return `${props.id}_input`;
}

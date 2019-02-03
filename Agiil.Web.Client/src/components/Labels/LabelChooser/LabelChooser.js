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

export default function labelChooser(props : LabelChooserProps) {
    const behaviours = new LabelChooserBehaviours(props);
    const inputId = getInputId(props);

    function onPickerKeypress(ev) { behaviours.onKeypress(ev); }
    function onPickerChange(ev) { behaviours.onChange(ev); }

    return (
        <div className={styles.LabelChooser || 'LabelChooser'} id={props.id}>
            { getInputLabel(props, inputId) }
            <SelectedLabelList
                labels={props.labels}
                onRemove={label => props.onRemove(label, props.selectedLabelsComponentId)}
                />
            <LabelPicker
                onKeypress={onPickerKeypress}
                onChange={onPickerChange}
                inputValue={props.inputValue}
                inputId={inputId}
                onFocusChanged={val => props.onShowSuggestionsChanged(val, props.componentId)}
                />
            <LabelSuggestions 
                suggestions={props.suggestions || []}
                show={props.showSuggestions || false}
                onClickSuggestion={label => props.onClickSuggestion(label, props.suggestionsComponentId)}
                noSuggestionsLoaded={props.noSuggestionsLoaded}
                suggestionsLoading={props.suggestionsLoading}
                />
        </div>
    );
}

function getInputLabel(props : LabelChooserProps, inputId : ?string) {
    const hideInputLabel = !(props.uiLabelText && props.uiLabelText.length);
    if(hideInputLabel) return null;

    return <label htmlFor={inputId}>{props.uiLabelText}</label>;
}

function getInputId(props : LabelChooserProps) : ?string {
    return props.id || null;
}

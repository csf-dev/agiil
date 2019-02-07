//@flow
import * as React from "react";
import { Lister as SuggestionLister, Suggestion } from 'components/common/SuggestionsList';
import { LabelList, Label } from 'components/labels/LabelList';
import type { SelectableLabel } from 'models/labels';
import type { LabelChooserProps } from './LabelChooserProps';
import LabelChooserBehaviours from './LabelChooserBehaviours';
// $FlowFixMe
import styles from './labelChooser.scss';

export function LabelChooser(props : LabelChooserProps) {
    const behaviours = new LabelChooserBehaviours(props);
    const suggestions = props.suggestions || [];
    return (
        <div className={styles.labelChooser} id={props.id}>
            {getUiLabel(props)}
            <LabelList>
            {props.labels.map(label => {
                <Label label={label} title={`Label: ${label.name}`}>
                    {label.name}
                    <button className={styles.remove}
                            title="Remove"
                            onClick={() => props.onRemove(label, props.selectedLabelsComponentId)}>❌</button>
                </Label>
            })}
            </LabelList>
            <input id={getInputId(props)}
                   onKeyDown={behaviours.onKeypress}
                   onChange={behaviours.onKeypress}
                   value={props.inputValue || ''}
                   onFocus={behaviours.onFocus}
                   onBlur={behaviours.onBlur} />
            <SuggestionLister ineligibleForSuggestions={props.noSuggestionsLoaded}
                              ineligibleForSuggestionsMessage="Type for label suggestions"
                              emptySuggestionsList={!suggestions.length}
                              emptySuggestionsListMessage="No matching labels"
                              suggestionsLoading={props.suggestionsLoading}
                              visible={props.showSuggestions}>
            {suggestions.map(suggestion => {
                <Suggestion selected={suggestion.selected} onChoose={() => behaviours.onChooseSuggestion(suggestion)}>
                    <strong>{suggestion.name}</strong>
                    {getOpenCount(suggestion)}
                    {getClosedCount(suggestion)}
                </Suggestion>
            })}
            </SuggestionLister>
        </div>
    );
}

function getUiLabel(props : LabelChooserProps) {
    if(!props.uiLabelText) return null;
    const inputId = getInputId(props);
    return <label htmlFor={inputId}>{props.uiLabelText}</label>
}

function getInputId(props : LabelChooserProps) { return props.id? `${props.id}_input` : null; }

function getTicketOrTickets(count : number) {
    if(count == 1) return 'ticket';
    return 'tickets';
}

function getOpenCount(label : SelectableLabel) {
    const count = label.openTickets;
    if(typeof count !== 'number') return null;
    return <span className={`${styles.ticketCount} ${styles.open}`}>{count} open {getTicketOrTickets(count)}</span>
}

function getClosedCount(label : SelectableLabel) {
    const count = label.closedTickets;
    if(typeof count !== 'number') return null;
    return <span className={`${styles.ticketCount} ${styles.closed}`}>{count} closed {getTicketOrTickets(count)}</span>
}
//@flow
import * as React from "react";
import { Lister as SuggestionLister, Suggestion } from 'components/common/SuggestionsList';
import { LabelList, Label } from 'components/labels/LabelList';
import type { SelectableLabel } from 'models/labels';
import type { LabelChooserProps } from './LabelChooserProps';
import LabelChooserBehaviours from './LabelChooserBehaviours';
// $FlowFixMe
import styles from './labelChooser.module.scss';
// $FlowFixMe
import './labelChooser.scss';

export function LabelChooser(props : LabelChooserProps) {
    const behaviours = new LabelChooserBehaviours(props);
    const suggestions = props.suggestions || [];
    const labels = props.labels || [];
    return (
        <div className={`${styles.labelChooser} LabelChooser`} id={props.id}>
            {getUiLabel(props)}
            <LabelList>
            {labels.map((label, idx) =>
                <Label label={label} title={`Label: ${label.name}`} key={idx}>
                    {label.name}
                    <button className={styles.remove}
                            title="Remove"
                            onClick={ev => { props.onRemove(label, props.selectedLabelsComponentId); ev.preventDefault(); }}>❌</button>
                </Label>
            )}
            </LabelList>
            <input type="hidden" name={props.name} value={getCommaSeparatedLabelNames(labels)} />
            <input id={getInputId(props)}
                   type="text"
                   onKeyDown={behaviours.onKeypress}
                   onChange={behaviours.onChange}
                   value={props.inputValue || ''}
                   onFocus={behaviours.onFocus}
                   onBlur={behaviours.onBlur} />
            <SuggestionLister ineligibleForSuggestions={props.noSuggestionsLoaded}
                              ineligibleForSuggestionsMessage="Type for label suggestions"
                              emptySuggestionsList={!suggestions.length}
                              emptySuggestionsListMessage="No matching labels"
                              suggestionsLoading={props.suggestionsLoading}
                              visible={props.showSuggestions}
                              onMouseDown={behaviours.onMouseDownSuggestions}
                              onTouchStart={behaviours.onMouseDownSuggestions}>
            {suggestions.map((suggestion, idx) =>
                <Suggestion selected={suggestion.selected} onChoose={() => behaviours.onChooseSuggestion(suggestion)} key={idx}>
                    <strong>{suggestion.name}</strong>
                    {getOpenCount(suggestion)}
                    {getClosedCount(suggestion)}
                </Suggestion>
            )}
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
    const countMessage = `${count} open ${getTicketOrTickets(count)}`;
    return <span className={`${styles.ticketCount} ${styles.open}`} title={countMessage}>{count} open</span>
}

function getClosedCount(label : SelectableLabel) {
    const count = label.closedTickets;
    if(typeof count !== 'number') return null;
    const countMessage = `${count} closed ${getTicketOrTickets(count)}`;
    return <span className={`${styles.ticketCount} ${styles.closed}`} title={countMessage}>{count} closed</span>
}
function getCommaSeparatedLabelNames(labels : Array<SelectableLabel>) {
    return labels.map(x => x.name).join(',');
}
//@flow
import * as React from "react";
import type { SelectableLabel } from '../../../domain/Labels/Label';
import LabelSuggestion from './LabelSuggestion';

type Props = {
    suggestions: Array<SelectableLabel>,
    show : bool,
    noSuggestionsLoaded : bool,
    suggestionsLoading : bool,
    onClickSuggestion : (label : SelectableLabel) => void
};

export default function LabelSuggestions(props : Props) {
    return (
        <div className={getClassNames(props).join(' ')}>
            {getFeedbackMessage(props)}
            <ul>
                {getSuggections(props)}
            </ul>
        </div>
    );
}

function getSuggections(props : Props) {
    return props.suggestions.map(getSuggestionMapper(props));
}

function getSuggestionMapper(props : Props) {
    return (label : SelectableLabel) => {
        return (
            <LabelSuggestion
                label={label}
                clickable={props.show && !props.suggestionsLoading}
                onClick={props.onClickSuggestion}  />
        );
    }
}

function getClassNames(props : Props) {
    const classNames = ['LabelSuggestions'];

    if(props.noSuggestionsLoaded)
        classNames.push('no_suggestions');
    else if(!props.suggestions.length)
        classNames.push('empty_suggestions');

    if(props.suggestionsLoading)
        classNames.push('loading');

    return classNames;
}

function getFeedbackMessage(props : Props) {
    if(props.noSuggestionsLoaded)
        return <p>Type to see suggestions</p>
    else if(!props.suggestions.length)
        return <p>No suggestions available</p>
    return null;
}

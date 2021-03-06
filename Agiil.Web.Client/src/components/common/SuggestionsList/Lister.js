//@flow
import * as React from "react";
// $FlowFixMe
import styles from './suggestionsList.module.scss';
// $FlowFixMe
import commonStyles from 'components/componentStyles.module.scss';

export type ListerProps = {
    ineligibleForSuggestions? : bool,
    ineligibleForSuggestionsMessage? : string,
    emptySuggestionsList? : bool,
    emptySuggestionsListMessage? : string,
    suggestionsLoading? : bool,
    visible? : bool,
    children: React.Node,
    onMouseDown? : (ev : SyntheticEvent<HTMLElement>) => void,
    onTouchStart? : (ev : SyntheticEvent<HTMLElement>) => void,
};

const defaultProps = {
    ineligibleForSuggestions: false,
    ineligibleForSuggestionsMessage: 'Type to get suggestions',
    emptySuggestionsList: false,
    emptySuggestionsListMessage: 'No suggestions',
    suggestionsLoading: false,
    visible: false,
    onMouseDown : (ev : SyntheticEvent<HTMLElement>) => {},
    onTouchStart : (ev : SyntheticEvent<HTMLElement>) => {},
}

export function Lister(rawProps : ListerProps) {
    const props : ListerProps = Object.assign({}, defaultProps, rawProps);
    const listerClass = getClassNames(props).join(' ');

    return (
        <div className={listerClass}
             onMouseDown={props.onMouseDown}
             onTouchStart={props.onMouseDown}>
            {getFeedback(props)}
            <ul>
                {props.children}
            </ul>
        </div>
    );

}

function getClassNames(props : ListerProps) : Array<string> {
    const out = [ styles.suggestions, 'SuggestionsList' ];
    if(props.ineligibleForSuggestions) out.push(styles.ineligible);
    if(props.emptySuggestionsList) out.push(styles.empty);
    if(props.suggestionsLoading) out.push(styles.loading);
    if(!props.visible) out.push(commonStyles.hidden);
    return out;
}

function getFeedback(props : ListerProps) : ?React.Node {
    let message : ?string = null;
    if(props.ineligibleForSuggestions) message = props.ineligibleForSuggestionsMessage;
    else if(props.emptySuggestionsList) message = props.emptySuggestionsListMessage;

    if(message === null) return null;
    return <p className={styles.feedback}>{message}</p>;
}
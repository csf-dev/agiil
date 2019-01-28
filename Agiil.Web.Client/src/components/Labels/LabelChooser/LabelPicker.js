//@flow
import * as React from "react";
import { RequestsDataAsync } from '../../../GetsDataAsync';
import type { Label } from '../../../domain/Labels/Label';

type Props = {
    inputValue : ?string,
    onKeypress: (ev: SyntheticKeyboardEvent<HTMLInputElement>) => void,
    inputId : ?string,
    onFocusChanged: (isFocussed : bool) => void,
    onChange: (ev : SyntheticEvent<HTMLInputElement>) => void
};

export default function LabelPicker(props : Props) {
    function onInputFocus() { props.onFocusChanged(true); }
    function onInputBlur() { props.onFocusChanged(false); }
    function onKeypress(ev) { props.onKeypress(ev); }
    function onChange(ev) { props.onChange(ev); }

    return (
        <input
            id={props.inputId}
            onKeyPress={props.onKeypress}
            onChange={onChange}
            value={props.inputValue || ''}
            onFocus={onInputFocus}
            onBlur={onInputBlur} />
    );
}
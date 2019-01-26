//@flow
import type { LabelChooserProps } from './LabelChooserProps';
import Keyboard from '../../../util/Keyboard';
import type { SelectableLabel } from '../../../domain/Labels/Label';

export default class LabelChooserBehaviours {
    props : LabelChooserProps;

    onKeypress = (ev: SyntheticKeyboardEvent<HTMLInputElement>) => {
        switch(ev.key) {
        case Keyboard.Backspace:
            if(mayPressBackspaceToRemoveLabel(ev))
                handleRemoval(this.props);
            break;
        
        case Keyboard.Enter:
        case ",":
            handleAddition(this.props);
            ev.preventDefault();
            break;

        case Keyboard.ArrowDown:
            this.props.onSelectNextSuggestion();
            ev.preventDefault();
            break;

        case Keyboard.ArrowUp:
            this.props.onSelectPrevSuggestion();
            ev.preventDefault();
            break;
        }

        if(ev.key !== Keyboard.Backspace)
            deselectAllForRemoval(this.props);

        if(![Keyboard.ArrowDown, Keyboard.ArrowUp].includes(ev.key))
            this.props.onResetSelectedSuggestion();
        
        if(ev.currentTarget.value != this.props.inputValue)
            handleChangeValue(this.props, ev.currentTarget.value);
    };

    onChange = (ev : SyntheticEvent<HTMLInputElement>) => {
        handleChangeValue(this.props, ev.currentTarget.value);
    }

    constructor(props : LabelChooserProps) {
        this.props = props;
    }
}

function mayPressBackspaceToRemoveLabel(ev : SyntheticKeyboardEvent<HTMLInputElement>) {
    return (ev.currentTarget.selectionStart === 0
            && ev.currentTarget.selectionEnd === 0);
}

function handleRemoval(props : LabelChooserProps) {
    const labelCount = props.labels.length;
    if (!labelCount) return;
    
    const label = props.labels[labelCount - 1];

    if(label.selected)
        props.onRemove(label);
    else
        props.onSelectForRemoval(label);
}

function getSelected(suggestions : ?Array<SelectableLabel>) : ?SelectableLabel {
    if(!suggestions || !suggestions.length) return null;
    return suggestions.find(label => label.selected);
}

function handleAddition(props : LabelChooserProps) {
    const selectedLabel = getSelected(props.suggestions);

    if(selectedLabel)
        props.onAdd(selectedLabel);
    else if(props.inputValue)
        props.onAdd({ name: props.inputValue });
}

function deselectAllForRemoval(props : LabelChooserProps) {
    props.labels.forEach(label => {
        if(!label.selected) return;
        props.onDeselectForRemoval(label);
    })
}

function handleChangeValue(props : LabelChooserProps, newValue : string) {
    props.onInputValueChanged(newValue);
}
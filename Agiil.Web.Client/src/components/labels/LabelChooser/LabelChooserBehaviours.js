//@flow
import type { LabelChooserProps } from './LabelChooserProps';
import Keyboard from 'util/Keyboard';
import type { SelectableLabel } from 'models/labels';
import bound from 'bound-decorator';

export default class LabelChooserBehaviours {
    props : LabelChooserProps;

    @bound
    onKeypress(ev: SyntheticKeyboardEvent<HTMLInputElement>) {
        switch(ev.key) {
        case Keyboard.Backspace:
            if(mayPressBackspaceToRemoveLabel(ev))
                handleRemoval(this.props);
            break;
        
        case Keyboard.Enter:
        case ",":
            handleAddition(this.props);
            handleChangeValue(this.props, '');
            ev.preventDefault();
            break;

        case Keyboard.ArrowDown:
            this.props.onSelectNextSuggestion(this.props.suggestionsComponentId);
            ev.preventDefault();
            break;

        case Keyboard.ArrowUp:
            this.props.onSelectPrevSuggestion(this.props.suggestionsComponentId);
            ev.preventDefault();
            break;
        }

        if(ev.key !== Keyboard.Backspace)
            deselectAllForRemoval(this.props);

        if(![Keyboard.ArrowDown, Keyboard.ArrowUp].includes(ev.key))
            this.props.onResetSelectedSuggestion(this.props.suggestionsComponentId);
    };

    @bound
    onChange(ev : SyntheticEvent<HTMLInputElement>) {
        handleChangeValue(this.props, ev.currentTarget.value);
    };

    @bound
    onFocus() { this.props.onShowSuggestionsChanged(true, this.props.componentId); }

    @bound
    onBlur() { this.props.onShowSuggestionsChanged(false, this.props.componentId); }

    @bound
    onChooseSuggestion(suggestion : SelectableLabel) {
        this.props.onClickSuggestion(suggestion, this.props.suggestionsComponentId);
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
        props.onRemove(label, props.selectedLabelsComponentId);
    else
        props.onSelectForRemoval(label, props.selectedLabelsComponentId);
}

function getSelected(suggestions : ?Array<SelectableLabel>) : ?SelectableLabel {
    if(!suggestions || !suggestions.length) return null;
    return suggestions.find(label => label.selected);
}

function handleAddition(props : LabelChooserProps) {
    const selectedLabel = getSelected(props.suggestions);

    if(selectedLabel)
        props.onAdd(selectedLabel, props.selectedLabelsComponentId);
    else if(props.inputValue)
        props.onAdd({ name: props.inputValue }, props.selectedLabelsComponentId);
}

function deselectAllForRemoval(props : LabelChooserProps) {
    props.onDeselectForRemoval(props.selectedLabelsComponentId);
}

function handleChangeValue(props : LabelChooserProps, newValue : string) {
    props.onInputValueChanged(newValue, props.componentId, props.labelSuggester);
}
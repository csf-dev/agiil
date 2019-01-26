//@flow
import SelectedLabelList from './SelectedLabelList';
import type { SelectableLabel } from '../../../domain/Labels/Label';
import ReactDOM from 'react-dom';
import React from "react";

function getDocElement() {
    if(!document.documentElement) throw new Error('Document element missing');
    return document.documentElement;
}

describe('The selected-labels list', () => {
    it('should be able to render three labels with a variety of properties', () => {
        const labels = [
            { name: 'One', selected: false },
            { name: 'Two', selected: true },
            { name: 'Three', selected: false }
        ];
        const root = document.createElement('div');
        getDocElement().appendChild(root);

        ReactDOM.render(<SelectedLabelList labels={labels} onRemove={x => {}} />, root);

        expect(root.innerHTML).toEqual('<ul class="SelectedLabelList">' +
        '<li class="" title="Label \'One\'">One<button class="remove-label" title="Remove">❌</button></li>' +
        '<li class="for-removal" title="Label \'Two\'">Two<button class="remove-label" title="Remove">❌</button></li>' +
        '<li class="" title="Label \'Three\'">Three<button class="remove-label" title="Remove">❌</button></li>' +
        '</ul>');
    });
});
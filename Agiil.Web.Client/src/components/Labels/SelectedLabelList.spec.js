//@flow
import SelectedLabelList from './SelectedLabelList';
import type { RemovableLabel } from '../../models/Labels/Label';
import ReactDOM from 'react-dom';
import React from "react";

function getDocElement() {
    if(!document.documentElement) throw new Error('Document element missing');
    return document.documentElement;
}

describe('The selected-labels list', () => {
    it('should be able to render three labels with a variety of properties', () => {
        const labels = [
            { name: 'One', selectedForRemoval: false },
            { name: 'Two', selectedForRemoval: true },
            { name: 'Three', selectedForRemoval: false, openTickets: 1, closedTickets: 5 }
        ];
        const root = document.createElement('div');
        getDocElement().appendChild(root);

        ReactDOM.render(<SelectedLabelList labels={labels} onRemove={x => {}} />, root);

        expect(root.innerHTML).toEqual('<ul class="SelectedLabelList">' +
        '<li class="" title="">One<button class="remove-label" title="Remove">❌</button></li>' +
        '<li class="for-removal" title="">Two<button class="remove-label" title="Remove">❌</button></li>' +
        '<li class="" title="1 open ticket, 5 closed tickets">Three<button class="remove-label" title="Remove">❌</button></li>' +
        '</ul>');
    });
});
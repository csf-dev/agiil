//@flow
import React from 'react';
import ReactDOM from 'react-dom';
import { getElementByIdMandatory } from '../../../util/TestDom';
import LabelChooser from './LabelChooser';
import { getSampleProps } from './getSampleProps';

function startPage() {
    const root = getElementByIdMandatory('root');
    const sampleProps = getSampleProps();
    sampleProps.suggestions = [
        { name: 'Three', selected: false, openTickets: 5, closedTickets: 24 },
        { name: 'Four', selected: true, openTickets: 1 },
        { name: 'Five', selected: false }
    ];
    sampleProps.showSuggestions = true;
    ReactDOM.render(<LabelChooser {...sampleProps} />, root);
}

document.addEventListener("DOMContentLoaded", startPage);

//@flow
import { Label } from './Label';
import type { TitleFormatter } from './Label';
import ReactDOM from 'react-dom';
import React from "react";
import type { SelectableLabel } from 'models/labels';
import { getTestDom, testDomId } from 'util/TestDom';
import mandatory from 'util/mandatory';
// $FlowFixMe
import styles from './labelList.scss';

describe('A selectable label item', () => {
    let label : SelectableLabel;
    let root : HTMLDivElement;

    beforeEach(() => {
        root = getTestDom(); 
        label = { name: 'This is a label', selected: false, openTickets: 5, closedTickets: 10 };
    })

    afterEach(() => {
        if(root) root.remove();
    });

    it('should have a formatted title when it is specified', () => {
        const formatter : TitleFormatter = label => `TITLE: ${label.name}`;
        ReactDOM.render(<Label label={label} titleFormatter={formatter}>{label.name}</Label>, root);
        const item = mandatory(document.querySelector(itemSelector));
        expect(item.title).toBe('TITLE: This is a label');
    });

    it('should have a static title when it is specified', () => {
        ReactDOM.render(<Label label={label} title={'FOO BAR'}>{label.name}</Label>, root);
        const item = mandatory(document.querySelector(itemSelector));
        expect(item.title).toBe('FOO BAR');
    });

    it('should not have a title when no formatter is specified', () => {
        ReactDOM.render(<Label label={label}>{label.name}</Label>, root);
        const item = mandatory(document.querySelector(itemSelector));
        expect(item.title).toBeFalsy();
    });

    it('should not have the selected class if the label is not selected', () => {
        label.selected = false;
        ReactDOM.render(<Label label={label}>{label.name}</Label>, root);
        const item = mandatory(document.querySelector(itemSelector));
        expect(item.className).toBeFalsy();
    });

    it('should have the selected class if the label is selected', () => {
        label.selected = true;
        ReactDOM.render(<Label label={label}>{label.name}</Label>, root);
        const item = mandatory(document.querySelector(itemSelector));
        expect(item.className).toBe(styles.selected);
    });
});

const itemSelector = `#${testDomId}>li`;

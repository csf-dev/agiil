//@flow
import SelectedLabelList from './SelectedLabelList';
import type { SelectableLabel } from '../../../domain/Labels/Label';
import ReactDOM from 'react-dom';
import React from "react";
import { getTestDom, testDomId } from '../../../util/TestDom';
import mandatory from '../../../util/mandatory';

describe('The selected-labels list', () => {
    let root : HTMLDivElement;

    beforeEach(() => {
        if(root) root.remove();
        root = getTestDom(); 
    })

    it('should have the correct root class name', () => {
        ReactDOM.render(<SelectedLabelList labels={sampleLabels} onRemove={x => {}} />, root);
        const rootList = mandatory(document.querySelector(rootSelector));
        expect(rootList.className).toBe('SelectedLabels');
    });

    describe('should render list items', () => {
        it('for every suggested label', () => {
            ReactDOM.render(<SelectedLabelList labels={sampleLabels} onRemove={x => {}} />, root);
            const rootList = mandatory(document.querySelector(rootSelector));
            expect(rootList.childElementCount).toBe(3);
        });

        it('which should be titled based on the labels', () => {
            ReactDOM.render(<SelectedLabelList labels={sampleLabels} onRemove={x => {}} />, root);
            const items = document.querySelectorAll(itemSelector);
            const titles = [...items].map(x => x.title);
            const expectedTitles = sampleLabels.map(x => `Label '${x.name}'`);
            expect(titles).toEqual(expectedTitles);
        });

        it('which should be marked with a for-removal class if the label is selected', () => {
            ReactDOM.render(<SelectedLabelList labels={sampleLabels} onRemove={x => {}} />, root);
            const item = mandatory(document.querySelector(secondItemSelector));
            expect(item.className).toEqual('forRemoval');
        });

        it('which should not be marked with any class if the label is not selected', () => {
            ReactDOM.render(<SelectedLabelList labels={sampleLabels} onRemove={x => {}} />, root);
            const item = mandatory(document.querySelector(firstItemSelector));
            expect(item.className).toBe('');
        });

        it('which have text matching their name', () => {
            ReactDOM.render(<SelectedLabelList labels={sampleLabels} onRemove={x => {}} />, root);
            const items = document.querySelectorAll(itemSelector);
            const texts = [...items].map(x => mandatory(x.firstChild).nodeValue);
            const expectedTexts = sampleLabels.map(x => x.name);
            expect(texts).toEqual(expectedTexts);
        });

        it('each of which has a removal button', () => {
            ReactDOM.render(<SelectedLabelList labels={sampleLabels} onRemove={x => {}} />, root);
            const items = document.querySelectorAll(itemSelector);
            const buttons = [...items]
                .map(x => x.querySelector('button'))
                .filter(x => x !== null);
            expect(buttons.length).toBe(3);
        });
    });
});

const sampleLabels = [
    { name: 'One', selected: false },
    { name: 'Two', selected: true },
    { name: 'Three', selected: false }
];
const rootSelector = `#${testDomId}>ul`;
const itemSelector = `#${testDomId}>ul>li`;
const firstItemSelector = `#${testDomId}>ul>li:nth-child(1)`;
const secondItemSelector = `#${testDomId}>ul>li:nth-child(2)`;
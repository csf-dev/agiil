//@flow
import ReactDOM from 'react-dom';
import ReactTestUtils from 'react-dom/test-utils'; 
import React from "react";
import { Suggestion } from './Suggestion';
import { getTestDom, testDomId } from 'util/TestDom';
import mandatory from 'util/mandatory';
// $FlowFixMe
import styles from './suggestionsList.module.scss';

describe('A suggestion item', () => {
    let root : HTMLDivElement;

    beforeEach(() => {
        root = getTestDom(); 
    });

    afterEach(() => {
        if(root) root.remove();
    });

    it('should always have the \'suggestion\' class', () => {
        ReactDOM.render(<Suggestion>Suggestion</Suggestion>, root);
        const rootElement = mandatory(document.querySelector(rootSelector));
        expect(rootElement.classList.contains(styles.suggestion)).toBeTruthy();
    });

    it('should have the \'selected\' class when the item is selected', () => {
        ReactDOM.render(<Suggestion selected={true}>Suggestion</Suggestion>, root);
        const rootElement = mandatory(document.querySelector(rootSelector));
        expect(rootElement.classList.contains(styles.selected)).toBeTruthy();
    });

    it('should not have the \'selected\' class when the item is not selected', () => {
        ReactDOM.render(<Suggestion selected={false}>Suggestion</Suggestion>, root);
        const rootElement = mandatory(document.querySelector(rootSelector));
        expect(rootElement.classList.contains(styles.selected)).toBeFalsy();
    });

    it('should trigger the appropriate onclick handler when clicked', () => {
        let clicked = false;
        const handler = () => clicked = true;
        ReactDOM.render(<Suggestion onChoose={handler}>Suggestion</Suggestion>, root);
        const rootElement = mandatory(document.querySelector(rootSelector));
        ReactTestUtils.Simulate.click(rootElement);
        expect(clicked).toBeTruthy();
    });

});

const rootSelector = `#${testDomId}>li`;

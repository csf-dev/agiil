//@flow
import ReactDOM from 'react-dom';
import React from "react";
import { Lister } from './Lister';
import { getTestDom, testDomId } from 'util/TestDom';
import mandatory from 'util/mandatory';
// $FlowFixMe
import styles from './suggestionsList.module.scss';

describe('The suggestion lister', () => {
    let root : HTMLDivElement;

    beforeEach(() => {
        root = getTestDom(); 
    })

    afterEach(() => {
        if(root) root.remove();
    });

    it('should always have the \'suggestions\' class', () => {
        ReactDOM.render(<Lister><li /></Lister>, root);
        const rootElement = mandatory(document.querySelector(rootSelector));
        expect(rootElement.classList.contains(styles.suggestions)).toBeTruthy();
    });

    it('should have the \'ineligible\' class when it is not eligible for suggestions', () => {
        ReactDOM.render(<Lister ineligibleForSuggestions={true}><li /></Lister>, root);
        const rootElement = mandatory(document.querySelector(rootSelector));
        expect(rootElement.classList.contains(styles.ineligible)).toBeTruthy();
    });

    it('should not have the \'ineligible\' class when it is eligible for suggestions', () => {
        ReactDOM.render(<Lister ineligibleForSuggestions={false}><li /></Lister>, root);
        const rootElement = mandatory(document.querySelector(rootSelector));
        expect(rootElement.classList.contains(styles.ineligible)).toBeFalsy();
    });

    it('should have the \'empty\' class when it is empty', () => {
        ReactDOM.render(<Lister emptySuggestionsList={true}><li /></Lister>, root);
        const rootElement = mandatory(document.querySelector(rootSelector));
        expect(rootElement.classList.contains(styles.empty)).toBeTruthy();
    });

    it('should not have the \'empty\' class when it is not empty', () => {
        ReactDOM.render(<Lister emptySuggestionsList={false}><li /></Lister>, root);
        const rootElement = mandatory(document.querySelector(rootSelector));
        expect(rootElement.classList.contains(styles.empty)).toBeFalsy();
    });

    it('should have the \'loading\' class when suggestions are loading', () => {
        ReactDOM.render(<Lister suggestionsLoading={true}><li /></Lister>, root);
        const rootElement = mandatory(document.querySelector(rootSelector));
        expect(rootElement.classList.contains(styles.loading)).toBeTruthy();
    });

    it('should not have the \'loading\' class when suggestions are not loading', () => {
        ReactDOM.render(<Lister suggestionsLoading={false}><li /></Lister>, root);
        const rootElement = mandatory(document.querySelector(rootSelector));
        expect(rootElement.classList.contains(styles.loading)).toBeFalsy();
    });

    it('should display no feedback if it is neither empty nor ineligible for suggestions', () => {
        ReactDOM.render(<Lister><li /></Lister>, root);
        const feedbackElement = document.querySelector(feedbackSelector);
        expect(feedbackElement).toBeNull();
    });

    it('should display the default feedback message when it is ineligible for suggestions', () => {
        ReactDOM.render(<Lister ineligibleForSuggestions={true}><li /></Lister>, root);
        const feedbackElement = document.querySelector(feedbackSelector);
        expect(feedbackElement?.textContent).toBe('Type to get suggestions');
    });

    it('should display the default feedback message when it is empty', () => {
        ReactDOM.render(<Lister emptySuggestionsList={true}><li /></Lister>, root);
        const feedbackElement = document.querySelector(feedbackSelector);
        expect(feedbackElement?.textContent).toBe('No suggestions');
    });

    it('should display a customised feedback message when it is ineligible for suggestions', () => {
        ReactDOM.render(<Lister ineligibleForSuggestions={true} ineligibleForSuggestionsMessage="FOO"><li /></Lister>, root);
        const feedbackElement = document.querySelector(feedbackSelector);
        expect(feedbackElement?.textContent).toBe('FOO');
    });

    it('should display a customised feedback message when it is empty', () => {
        ReactDOM.render(<Lister emptySuggestionsList={true} emptySuggestionsListMessage="BAR"><li /></Lister>, root);
        const feedbackElement = document.querySelector(feedbackSelector);
        expect(feedbackElement?.textContent).toBe('BAR');
    });

    it('should use the \'feedback\' class for the feedback message', () => {
        ReactDOM.render(<Lister emptySuggestionsList={true}><li /></Lister>, root);
        const feedbackElement = document.querySelector(feedbackSelector);
        expect(feedbackElement?.className).toBe(styles.feedback);
    });

    it('should render a \'<ul>\' element inside the root element', () => {
        ReactDOM.render(<Lister><li /></Lister>, root);
        const rootElement = mandatory(document.querySelector(rootSelector));
        const listElement = rootElement.querySelector('ul')
        expect(listElement).not.toBeNull();
    });

    it('should render the node\'s children inside the list', () => {
        ReactDOM.render(<Lister><li /></Lister>, root);
        const rootElement = mandatory(document.querySelector(rootSelector));
        const itemElement = rootElement.querySelector('ul>li')
        expect(itemElement).not.toBeNull();
    });
    
});

const rootSelector = `#${testDomId}>div`;
const feedbackSelector = `#${testDomId}>div>p`;
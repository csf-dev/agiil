//@flow
import ReactDOM from 'react-dom';
import React from "react";
import { LabelChooser } from './LabelChooser';
import { getTestDom, testDomId } from 'util/TestDom';
import mandatory from 'util/mandatory';
import { getSampleProps } from './getSampleProps';
// $FlowFixMe
import styles from './labelChooser.module.scss';

describe('The label chooser component', () => {
    let root : HTMLDivElement;

    beforeEach(() => {
        root = getTestDom(); 
    });

    afterEach(() => {
        if(root) root.remove();
    });

    it('should always use the \'labelChooser\' class', () => {
        ReactDOM.render(<LabelChooser {...getSampleProps()} />, root);
        const rootElement = mandatory(document.querySelector(rootSelector));
        expect(rootElement.className).toBe(styles.labelChooser);
    });

    it('should use the specified id attribute if provided', () => {
        const props = getSampleProps();
        props.id = 'FOO';
        ReactDOM.render(<LabelChooser {...props} />, root);
        const rootElement = mandatory(document.querySelector(rootSelector));
        expect(rootElement.id).toBe('FOO');
    });

    it('should not have an id attribute if it is not provided', () => {
        const props = getSampleProps();
        props.id = undefined;
        ReactDOM.render(<LabelChooser {...props} />, root);
        const rootElement = mandatory(document.querySelector(rootSelector));
        expect(rootElement.id).toBeFalsy();
    });

    describe('has a label which', () => {
        it('should not be rendered if the label text is empty', () => {
            const props = getSampleProps();
            props.uiLabelText = '';
            ReactDOM.render(<LabelChooser {...props} />, root);
            const labelElement = document.querySelector(labelSelector);
            expect(labelElement).toBeNull();
        });

        it('should not be rendered if the label text is null', () => {
            const props = getSampleProps();
            props.uiLabelText = undefined;
            ReactDOM.render(<LabelChooser {...props} />, root);
            const labelElement = document.querySelector(labelSelector);
            expect(labelElement).toBeNull();
        });

        it('should be rendered if the label text is not empty', () => {
            const props = getSampleProps();
            props.uiLabelText = 'Hello';
            ReactDOM.render(<LabelChooser {...props} />, root);
            const labelElement = document.querySelector(labelSelector);
            expect(labelElement).not.toBeNull();
        });

        it('should contain the specified label text', () => {
            const props = getSampleProps();
            props.uiLabelText = 'Hello';
            ReactDOM.render(<LabelChooser {...props} />, root);
            const labelElement = mandatory(document.querySelector(labelSelector));
            expect(labelElement.textContent).toBe('Hello');
        });

        it('should have a \'for\' attribute for the correct ID if it\'s provided', () => {
            const props = getSampleProps();
            props.id = 'an_id';
            props.uiLabelText = 'Hello';
            ReactDOM.render(<LabelChooser {...props} />, root);
            const labelElement = mandatory(document.querySelector(labelSelector));
            expect(labelElement.getAttribute('for')).toBe('an_id_input');
        });

        it('should not have a \'for\' attribute if the ID is empty', () => {
            const props = getSampleProps();
            props.id = '';
            props.uiLabelText = 'Hello';
            ReactDOM.render(<LabelChooser {...props} />, root);
            const labelElement = mandatory(document.querySelector(labelSelector));
            expect(labelElement.getAttribute('for')).toBeFalsy();
        });

        it('should not have a \'for\' attribute if the ID is null', () => {
            const props = getSampleProps();
            props.id = undefined;
            props.uiLabelText = 'Hello';
            ReactDOM.render(<LabelChooser {...props} />, root);
            const labelElement = mandatory(document.querySelector(labelSelector));
            expect(labelElement.getAttribute('for')).toBeFalsy();
        });
    });
});

const rootSelector = `#${testDomId}>div`;
const labelSelector = `#${testDomId}>div>label`;
const sampleLabel = 'Sample label';
//@flow
import LabelChooser from './LabelChooser';
import ReactDOM from 'react-dom';
import React from "react";
import { getTestDom, testDomId } from '../../../util/TestDom';
import { getSampleProps } from './getSampleProps';
import mandatory from '../../../util/mandatory';

describe('The label chooser component', () => {
    let root : HTMLDivElement;

    beforeEach(() => {
        if(root) root.remove();
        root = getTestDom(); 
    })

    it('should render without crashing', () => {
        expect(() => ReactDOM.render(<LabelChooser {...getSampleProps()} />, root))
            .not.toThrow()
    });

    it('should have the correct root element class', () => {
        ReactDOM.render(<LabelChooser {...getSampleProps()} />, root);
        const rootElement = mandatory(document.querySelector(rootSelector));
        expect(rootElement.className).toBe('LabelChooser');
    })

    describe('has a UI <label> element', () => {
        it('that should be visible when the label text is not blank', () => {
            const props = getSampleProps();
            props.uiLabelText = sampleLabel;
            ReactDOM.render(<LabelChooser {...props} />, root);
            const labelElement = document.querySelector(labelSelector);
            expect(labelElement).not.toBeNull();
        });

        it('that should be hidden when the label text is blank', () => {
            const props = getSampleProps();
            props.uiLabelText = '';
            ReactDOM.render(<LabelChooser {...props} />, root);
            const labelElement = document.querySelector(labelSelector);
            expect(labelElement).toBeNull();
        });

        it('that should be hidden when the label text is undefined', () => {
            const props = getSampleProps();
            props.uiLabelText = undefined;
            ReactDOM.render(<LabelChooser {...props} />, root);
            const labelElement = document.querySelector(labelSelector);
            expect(labelElement).toBeNull();
        });

        it('should have the specified text when visible', () => {
            const props = getSampleProps();
            props.uiLabelText = 'This is the test text';
            ReactDOM.render(<LabelChooser {...props} />, root);
            const labelElement = mandatory(document.querySelector(labelSelector));
            expect(labelElement.innerText).toBe('This is the test text');
        });

        it('should have the correct `for` attribute when passed via props', () => {
            const props = getSampleProps();
            props.uiLabelText = sampleLabel;
            props.id = 'INPUT_ID'
            ReactDOM.render(<LabelChooser {...props} />, root);
            const labelElement = mandatory(document.querySelector(labelSelector));
            expect(labelElement.getAttribute('for')).toBe('INPUT_ID');
        });

        it('should not have a `for` attribute props has an undefined ID', () => {
            const props = getSampleProps();
            props.uiLabelText = sampleLabel;
            props.id = undefined;
            ReactDOM.render(<LabelChooser {...props} />, root);
            const labelElement = mandatory(document.querySelector(labelSelector));
            expect(labelElement.getAttribute('for')).toBeNull();
        });
    });

});

const labelSelector = `#${testDomId}>div>label`;
const rootSelector = `#${testDomId}>div`;
const sampleLabel = 'Sample label';
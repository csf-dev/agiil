//@flow
import LabelChooser from './LabelChooser';
import ReactDOM from 'react-dom';
import React from "react";
import { getTestDom } from '../../../util/TestDom';
import { getSampleProps } from './getSampleProps';

describe('The label chooser', () => {
    it('should render without crashing', () => {
        const root = getTestDom();
        ReactDOM.render(<LabelChooser {...getSampleProps()} />, root);
    });
});

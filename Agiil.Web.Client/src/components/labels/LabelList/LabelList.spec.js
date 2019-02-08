//@flow
import { LabelList } from './LabelList';
import ReactDOM from 'react-dom';
import React from "react";
import { getTestDom, testDomId } from 'util/TestDom';
import mandatory from 'util/mandatory';
// $FlowFixMe
import styles from './labelList.module.scss';

describe('The selected-labels list', () => {
    let root : HTMLDivElement;

    beforeEach(() => {
        root = getTestDom(); 
    })

    afterEach(() => {
        if(root) root.remove();
    });

    it('should have the correct root class name', () => {
        ReactDOM.render(<LabelList><li /></LabelList>, root);
        const rootList = mandatory(document.querySelector(rootSelector));
        expect(rootList.className).toBe(styles.labelList);
    });
});

const rootSelector = `#${testDomId}>ul`;

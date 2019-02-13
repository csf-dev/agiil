//@flow
import React from 'react';
import ReactDOM from 'react-dom';
import { getElementByIdMandatory } from 'util/dom';
import { LabelChooser } from 'components/labels/LabelChooser';
import getStore from 'app/getStore';
import type { AnyStore } from 'util/redux/AnyStore';
import { Provider } from 'react-redux';
import pageStarter from 'util/pageStarter';
import getLabelListFactory from 'services/labels/LabelListFromTextInputCreator';

pageStarter(() => {
    const store = getInitialStore();
    renderComponents(store);
});

function getInitialStore() : AnyStore {
    const labelsInput : HTMLInputElement = (getElementByIdMandatory('Labels') : any);
    const labels = getLabelListFactory(labelsInput).getLabelList();
    return getStore({selectedLabels: labels});
}

function renderComponents(store : AnyStore) {
    const root = getElementByIdMandatory('LabelChooser');
    [...root.children].forEach(child => child.remove());

    ReactDOM.render(
        <Provider store={store}>
            <LabelChooser id="Labels" stateSelector={store => store} labelText="Labels" />
        </Provider>,
        root
    );
}
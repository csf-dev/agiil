//@flow
import React from 'react';
import ReactDOM from 'react-dom';
import { getElementByIdMandatory } from 'util/dom';
import { LabelChooser } from 'components/labels/LabelChooser';
import store from 'app/store';
import { Provider } from 'react-redux';

function startPage() {
    const root = getElementByIdMandatory('LabelChooser');
    [...root.children].forEach(child => child.remove());

    ReactDOM.render(
        <Provider store={store}>
            <LabelChooser id="Labels" stateSelector={store => store} labelText="Labels" />
        </Provider>,
        root
    );
}

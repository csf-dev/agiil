//@flow
import React from 'react';
import ReactDOM from 'react-dom';
import { getElementByIdMandatory } from '../util/TestDom';
import LabelChooser from '../components/Labels/LabelChooser';
import store from './store';
import { Provider } from 'react-redux';

function startPage() {
    const root = getElementByIdMandatory('root');
    ReactDOM.render(
        <Provider store={store}>
            <LabelChooser id="myLabelChooser" stateSelector={store => store} />
        </Provider>,
        root
    );
}

document.addEventListener("DOMContentLoaded", startPage);

//@flow
import React from 'react';
import ReactDOM from 'react-dom';
import { getElementByIdMandatory } from 'util/TestDom';
import { LabelChooser } from 'components/labels/LabelChooser';
import store from './store';
import { Provider } from 'react-redux';
import { RequestsDataAsync } from 'services';
import type { Label } from 'models/labels';
import type { Cancelable } from 'models';
import { v4 as uuid } from 'uuid';

function startPage() {
    const root = getElementByIdMandatory('root');
    const suggester : RequestsDataAsync<string,Array<Label>> = new DummySuggester();

    ReactDOM.render(
        <Provider store={store}>
            <LabelChooser id="myLabelChooser" stateSelector={store => store} labelSuggester={suggester} />
        </Provider>,
        root
    );
}

document.addEventListener("DOMContentLoaded", startPage);

class DummySuggester implements RequestsDataAsync<string,Array<Label>> {
    getDataAsync(request : string) : Cancelable<Array<Label>> {
        const labels : Array<Label> = [
            { name: 'Label one', openTickets: 5, closedTickets: 3 },
            { name: 'Label two', closedTickets: 22 },
            { name: 'Label three', openTickets: 101 },
            { name: 'Label four' },
        ];

        return function() {
            let
                timeout : TimeoutID,
                promise : Promise<Array<Label>>;
            
            promise = new Promise((res, rej) => {
                const out = (request === 'nope' || !request)? [] : labels
                timeout = setTimeout(() => res(out), 2000);
            });

            return {
                promise,
                requestId: uuid(),
                cancel: () => clearTimeout(timeout)
            };
        }();
    }
}
//@flow
import React from 'react';
import ReactDOM from 'react-dom';
import pageStarter from 'util/pageStarter';
import getStore from 'app/getStore';
import { MainPanel, PanelContainer } from 'components/pageLayout/ToggleablePanels'
import type { AnyStore } from 'util/redux/AnyStore';
import { Provider } from 'react-redux';

pageStarter(() => {
    const store = getInitialStore();
    renderComponents(store);
});

function getInitialStore() : AnyStore {
    return getStore({currentActivePagePanel: MainPanel});
}

function renderComponents(store : AnyStore) {
    const root = getPageArea();
    if(!root) return;

    const children = [...root.children];
    children.forEach(child => child.remove());

    ReactDOM.render(
        <Provider store={store}>
            <PanelContainer>
                {children}
            </PanelContainer>
        </Provider>,
        root
    );
}

function getPageArea() : ?HTMLElement {
    const elements : HTMLElement[] = document.getElementsByQuery('body > .page_area');
    if(!elements) return null;
    return elements[0];
}

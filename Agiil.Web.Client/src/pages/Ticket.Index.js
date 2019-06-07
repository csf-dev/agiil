//@flow
import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import type { AnyStore } from 'util/redux/AnyStore';
import pageStarter from 'util/pageStarter';
import { querySelectorMandatory } from 'util/dom';
import getStore from 'app/getStore';
import { MainPanel, PanelContainer, ApplicationMenu } from 'components/pageLayout'

pageStarter(() => {
    const store = getInitialStore();
    renderComponents(store);
});

function getInitialStore() : AnyStore {
    return getStore({currentActivePagePanel: MainPanel});
}

function renderComponents(store : AnyStore) {
    const
        root = querySelectorMandatory('body > .page_area'),
        children = [...root.children],
        appMenu = querySelectorMandatory('body > .page_area > nav.application_menu');

    ReactDOM.render(
        <Provider store={store}>
            <PanelContainer>
                <ApplicationMenu>{[...appMenu.children]}</ApplicationMenu>
                <ViewTicketContentArea />
            </PanelContainer>
        </Provider>,
        root,
        afterRender(root)
    );
}

function afterRender(root : HTMLElement) {
    return () => {
        const
            parent = root.parentElement,
            newChild = root.firstChild;
        if(!parent || !newChild) return;
        parent.replaceChild(newChild, root);
    };
}

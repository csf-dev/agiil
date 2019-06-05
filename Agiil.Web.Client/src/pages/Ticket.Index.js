//@flow
import React from 'react';
import ReactDOM from 'react-dom';
import pageStarter from 'util/pageStarter';
import getStore from 'app/getStore';
import { MainPanel, PanelContainer } from 'components/pageLayout/ToggleablePanels'
import type { AnyStore } from 'util/redux/AnyStore';
import { Provider } from 'react-redux';
import { ApplicationMenu } from 'components/pageLayout/ApplicationMenu';
import { ContentArea } from 'components/pageLayout/ContentArea';
import { querySelectorMandatory } from 'util/dom';
import { TicketPageHeader } from 'components/pageLayout/TicketPageHeader';
import { ContentContainer } from 'components/pageLayout/TicketContentContainer';

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
                <ContentArea>
                    <TicketPageHeader />
                    <ContentContainer>
                        <ViewTicketMainContent />
                        <ViewTicketAsides />
                    </ContentContainer>
                </ContentArea>
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

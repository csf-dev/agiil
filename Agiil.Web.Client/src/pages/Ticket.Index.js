//@flow
import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import type { AnyStore } from 'util/redux/AnyStore';
import pageStarter from 'util/pageStarter';
import { querySelectorMandatory } from 'util/dom';
import getStore from 'app/getStore';
import { MainPanel, PanelContainer, ApplicationMenu, PageFooter, PanelChangeIndicator } from 'components/pageLayout'
import { ViewTicketContentArea } from 'components/viewTicket';
import { getTicketDetailProvider } from 'services/tickets';
import 'scss/TicketDetail.scss';

pageStarter(() => {
    const store = getInitialStore();
    renderComponents(store);
});

function getInitialStore() : AnyStore {
    const provider = getTicketDetailProvider(window.ticketData);
    const ticket = provider.getTicketDetail();

    return getStore({
        activePagePanel: { activePanel: MainPanel },
        ticket,
        addComment: getAddCommentModel()
    });
}

function renderComponents(store : AnyStore) {
    const
        root = querySelectorMandatory('body > .page_root'),
        children = [...root.children],
        appMenu = querySelectorMandatory('body > .page_root > .page_area > nav.application_menu'),
        footer = querySelectorMandatory('body > .page_root > footer');

    ReactDOM.render(
        <Provider store={store}>
            <PanelContainer>
                <ApplicationMenu>{[...appMenu.children]}</ApplicationMenu>
                <ViewTicketContentArea />
            </PanelContainer>
            <PageFooter>{[...footer.children]}</PageFooter>
            <PanelChangeIndicator />
            <div id="modalHost" />
        </Provider>,
        root
    );
}

function getAddCommentModel() {
    return {
        commentBody: '',
        showSuccessMessage: !!document.querySelector('.success.AddCommentFeedbackMessage'),
        showInvalidCommentMessage: !!document.querySelector('.warning.AddCommentFeedbackMessage'),
    };
}
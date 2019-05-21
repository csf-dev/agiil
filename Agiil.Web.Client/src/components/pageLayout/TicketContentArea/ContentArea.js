//@flow
import * as React from "react";
import { getElementsHtml } from 'util/dom';
import { PageHeader } from 'components/pageLayout/TicketPageHeader';
import type { PageHeaderProps } from 'components/pageLayout/TicketPageHeader';
import { ContentContainer } from 'components/pageLayout/TicketContentContainer';
import type { ContentContainerProps } from 'components/pageLayout/TicketContentContainer';
import { querySelectorMandatory } from 'util/dom';

export type ContentAreaProps = {
    headerElement : HTMLElement,
    contentContainerElement : HTMLElement
};

export function ContentArea(props : ContentAreaProps) {
    const headerProps = getPageHeaderProps(props.headerElement);

    return (
        <section className="content_area">
            <PageHeader {...headerProps} />
            <ContentContainer children={[...props.contentContainerElement.children]} />
        </section>
    );
}

function getPageHeaderProps(headerElement : HTMLElement) : PageHeaderProps {
    const
        ticketRefWithHash = querySelectorMandatory('.ticket_identity .ticket_reference', headerElement).innerText || '',
        ticketRef = ticketRefWithHash.substring(1),
        ticketType = querySelectorMandatory('.ticket_identity .ticket_type', headerElement).innerText || '',
        ticketTitle = querySelectorMandatory('.title_content', headerElement).innerText || '';


    return { ticketType, ticketRef, ticketTitle };
}
//@flow
import * as React from 'react';
import { ContentArea, ContentContainer } from 'components/pageLayout';
import { ViewTicketPageHeader, ViewTicketMainContent, ViewTicketAsides } from 'components/viewTicket';

export default function ViewTicketContentArea() {
    return (
        <ContentArea>
            <ViewTicketPageHeader />
            <ContentContainer>
                <ViewTicketMainContent />
                <ViewTicketAsides />
            </ContentContainer>
        </ContentArea>
    );
}
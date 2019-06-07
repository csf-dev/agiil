//@flow
import * as React from "react";
import { TicketIdentity } from './TicketIdentity';
import { TitleContent } from './TitleContent';
import { ContentHeader } from 'components/pageLayout';

export type TicketPageHeaderProps = {
    ticketType : string,
    ticketRef : string,
    ticketTitle : string
};

export function TicketPageHeader(props : TicketPageHeaderProps) {
    return (
        <ContentHeader>
            <TicketIdentity reference={props.ticketRef} type={props.ticketType} />
            <TitleContent title={props.ticketTitle} />
        </ContentHeader>
    );
}
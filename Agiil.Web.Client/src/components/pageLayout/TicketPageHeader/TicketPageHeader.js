//@flow
import * as React from "react";
import { TicketIdentity } from './TicketIdentity';
import { TitleContent } from './TitleContent';

export type TicketPageHeaderProps = {
    ticketType : string,
    ticketRef : string,
    ticketTitle : string
};

export function TicketPageHeader(props : TicketPageHeaderProps) {
    return (
        <header>
            <TicketIdentity reference={props.ticketRef} type={props.ticketType} />
            <TitleContent title={props.ticketTitle} />
        </header>
    );
}
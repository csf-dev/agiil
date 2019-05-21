//@flow
import * as React from "react";
import { TicketIdentity } from './TicketIdentity';
import { TitleContent } from './TitleContent';

export type PageHeaderProps = {
    ticketType : string,
    ticketRef : string,
    ticketTitle : string
};

export function PageHeader(props : PageHeaderProps) {
    return (
        <header>
            <TicketIdentity reference={props.ticketRef} type={props.ticketType} />
            <TitleContent title={props.ticketTitle} />
        </header>
    );
}
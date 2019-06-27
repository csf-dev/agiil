//@flow
import * as React from "react";
import type { ViewTicketProps } from 'components/viewTicket';
import { AsideItem } from 'components/pageLayout';

export function TicketCreationInfo(props : ViewTicketProps) {
    return (
        <AsideItem>
            <h3>Created</h3>
            <p>
                Created by <strong id="TicketCreatorUsername">{props.ticket.author}</strong> on <strong>{props.ticket.humanReadableCreated}</strong>
            </p>
        </AsideItem>
    );
}

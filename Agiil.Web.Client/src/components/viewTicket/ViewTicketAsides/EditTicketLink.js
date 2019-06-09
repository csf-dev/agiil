//@flow
import * as React from "react";
import type { ViewTicketProps } from 'components/viewTicket';
import { AsideItem } from 'components/pageLayout';

export function EditTicketLink(props : ViewTicketProps) {
    return (
        <AsideItem>
            <h3>Edit</h3>
            <p>
                <a href={props.ticket.editUrl} id="EditTicketLink">Edit this ticket</a>
            </p>
        </AsideItem>
    );
}

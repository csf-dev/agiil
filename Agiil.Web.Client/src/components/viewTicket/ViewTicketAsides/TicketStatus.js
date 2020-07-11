//@flow
import * as React from "react";
import type { ViewTicketProps } from 'components/viewTicket';
import { AsideItem } from 'components/pageLayout';

export function TicketStatus(props : ViewTicketProps) {
    return (
        <AsideItem>
            <h3>Status</h3>
            <form className="open_close_ticket"
                  action={getOpenCloseActionUrl(props)}
                  method="POST">
                <fieldset>
                    <div className="form_element">
                        <p>
                            <span className="screen_reader_only">This ticket is</span>
                            <span className="ticket_state">{props.ticket.isClosed? 'Closed' : 'Open'}</span><span className="screen_reader_only">.</span>
                            {getOpenCloseButton(props)}
                        </p>
                    </div>
                </fieldset>
            </form>
        </AsideItem>
    );
}

function getOpenCloseButton(props : ViewTicketProps) {
    if(!props.ticket.canEdit) return null;
    return (<button id="OpenCloseButton">{props.ticket.isClosed? 'Re-open' : 'Close'}</button>);
}

function getOpenCloseActionUrl(props : ViewTicketProps) {
    const openClose = props.ticket.isOpen? 'Close' : 'Reopen';
    return `OpenCloseTicket/${openClose}/${props.ticket.id}`;
}
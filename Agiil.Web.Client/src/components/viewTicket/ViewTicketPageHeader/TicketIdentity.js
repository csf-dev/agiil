//@flow
import * as React from "react";
import TicketTypeIcon from 'components/TicketTypeIcon';

export type TicketIdentityProps = {
    reference : string,
    type : string
};

export function TicketIdentity(props : TicketIdentityProps) {
    return (
        <div className="ticket_identity">
            <TicketTypeIcon ticketType={props.type} />
            <span className="screen_reader_only">Ticket reference</span>
            <strong className="ticket_reference">#{props.reference}</strong>
        </div>
    );
}
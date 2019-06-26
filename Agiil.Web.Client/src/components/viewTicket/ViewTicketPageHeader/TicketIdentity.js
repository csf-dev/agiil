//@flow
import * as React from "react";

export type TicketIdentityProps = {
    reference : string,
    type : string
};

export function TicketIdentity(props : TicketIdentityProps) {
    return (
        <div className="ticket_identity">
            <span className="screen_reader_only">Ticket reference</span>
            <strong className="ticket_reference">#{props.reference}</strong>:
            <span className="ticket_type">{props.type}</span>
        </div>
    );
}
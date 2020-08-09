//@flow
import * as React from "react";

export type TicketTypeIconProps = {
    ticketType : string
};

export function TicketTypeIcon(props : TicketTypeIconProps) {
    const classNames = `TicketTypeIcon TicketTypeIcon_${props.ticketType}`;

    return (
        <i className={classNames}
           title={props.ticketType}
           aria-hidden="true">
            <span className="screen_reader_only">{props.ticketType}</span>
        </i>
    );
}
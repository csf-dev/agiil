//@flow
import * as React from "react";
import type { ViewTicketProps } from 'components/viewTicket';
import { AsideItem } from 'components/pageLayout';

export function TicketWorkLog(props : ViewTicketProps) {
    return (
        <AsideItem>
            <h3>Work log</h3>
            {getWorkLogMessage(props)}
            <p><a href={getLogWorkUrl(props)}>Log work</a></p>
        </AsideItem>
    );
}

function getWorkLogMessage(props : ViewTicketProps) {
    if(!props.ticket.hasWorkLogged)
        return (<p className="total_work_logged nothing_logged">No work logged</p>);

    return (
        <p className="total_work_logged">
            <span className="total_minutes">{props.ticket.workLoggedMinutes}</span> minutes of work logged
        </p>
    );
}

function getLogWorkUrl(props : ViewTicketProps) {
    return `AddTicketWorkLog/Index/${props.ticket.reference}`;
}
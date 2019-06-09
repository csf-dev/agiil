//@flow
import * as React from "react";
import type { ViewTicketProps } from 'components/viewTicket';
import { AsideItem } from 'components/pageLayout';

export function TicketSprint(props : ViewTicketProps) {
    return (
        <AsideItem>
            <h3>Sprint</h3>
            {getSprintMarkup(props)}
        </AsideItem>
    );
}

function getSprintMarkup(props : ViewTicketProps) {
    if(!props.ticket.sprint)
        return (<p>This ticket is not part of any sprint</p>);

    return (
        <p>
            <span className="screen_reader_only">This ticket is part of</span>
            <a href={getSprintUrl(props)}><strong className="TicketSprintName">{props.ticket.sprint.name}</strong></a>
        </p>
    );
}

function getSprintUrl(props : ViewTicketProps) {
    const sprintId = props.ticket.sprint?.id || 0;
    return `Sprint/Index/${sprintId}`;
}
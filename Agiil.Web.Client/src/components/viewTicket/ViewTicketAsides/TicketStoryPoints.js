//@flow
import * as React from "react";
import type { ViewTicketProps } from 'components/viewTicket';
import { AsideItem } from 'components/pageLayout';

export function TicketStoryPoints(props : ViewTicketProps) {
    return (
        <AsideItem>
            <h2>Story point estimate</h2>
            {getStoryPointMessage(props)}
        </AsideItem>
    );
}

function getStoryPointMessage(props : ViewTicketProps) {
    if(!props.ticket.storyPoints)
        return (<p className="story_point_estimate no_estimate">No story point estimate</p>);

    const pointOrPoints = (props.ticket.storyPoints > 1)? 'points' : 'point';
    return (
        <p className="story_point_estimate">
            <span className="value">{props.ticket.storyPoints}</span> story {pointOrPoints}
        </p>
    );
}
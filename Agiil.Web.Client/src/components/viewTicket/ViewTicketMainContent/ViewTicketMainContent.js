//@flow
import * as React from "react";
import { MainContent } from 'components/pageLayout';
import { TicketDescription } from './TicketDescription';
import { CommentsList, AddAComment } from '../TicketComments';
import TicketDetail from 'models/tickets/TicketDetail';

export function ViewTicketMainContent(props : { ticket : TicketDetail }) {
    return (
        <MainContent>
            <section className="ticket_description">
                <header>
                    <h2 className="screen_reader_only">Ticket description</h2>
                </header>
                <TicketDescription markup={props.ticket.descriptionMarkup} />
            </section>
            <section className="ticket_comments">
                <header>
                    <h2>Ticket comments</h2>
                </header>
                <CommentsList ticket={props.ticket} />
                <AddAComment ticket={props.ticket} stateSelector={x => x} />
            </section>
        </MainContent>
    );
}
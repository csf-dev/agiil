//@flow
import { connect } from 'react-redux';
import type { TicketPageHeaderProps } from './TicketPageHeader'
import { TicketPageHeader } from './TicketPageHeader';

function mapStateToProps(store : any) : TicketPageHeaderProps {
    return {
        ticketType: store.ticket.type,
        ticketRef : store.ticket.reference,
        ticketTitle : store.ticket.title
    };
}

const connectedTicketPageHeader = connect<TicketPageHeaderProps,any, any, any, any, any>(
    mapStateToProps
)(TicketPageHeader);
export { connectedTicketPageHeader };
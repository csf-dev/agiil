//@flow
import { connect } from 'react-redux';
import type { ViewTicketProps } from 'components/viewTicket';
import { ViewTicketMainContent } from './ViewTicketMainContent';

function mapStateToProps(store : any) : ViewTicketProps {
    return {
        ticket: store.ticket,
    };
}

const connectedViewTicketMainContent = connect<ViewTicketProps,any, any, any, any, any>(
    mapStateToProps
)(ViewTicketMainContent);
export { connectedViewTicketMainContent };
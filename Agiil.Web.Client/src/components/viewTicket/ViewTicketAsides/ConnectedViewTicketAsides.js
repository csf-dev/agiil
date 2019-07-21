//@flow
import { connect } from 'react-redux';
import type { ViewTicketProps } from 'components/viewTicket';
import { ViewTicketAsides } from './ViewTicketAsides';

function mapStateToProps(store : any) : ViewTicketProps {
    return {
        ticket: store.ticket,
    };
}

const connectedViewTicketAsides = connect<ViewTicketProps,any, any, any, any, any>(
    mapStateToProps
)(ViewTicketAsides);
export { connectedViewTicketAsides };
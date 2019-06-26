//@flow
import TicketDetail from 'models/tickets/TicketDetail';

function TicketDetailReducer(state : ?TicketDetail, action : any) : TicketDetail {
    return state || new TicketDetail(0, '0', '');
}

export { TicketDetailReducer as reducer }
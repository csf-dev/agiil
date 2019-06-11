//@flow
import { connect } from 'react-redux';
import { AddAComment } from './AddAComment';
import type { AddACommentProps } from './AddAComment';
import type { AddACommentState } from './AddACommentState';
import type { ComponentId } from 'models';
import { updateComponentTextValue } from 'actions';
import TicketDetail from 'models/tickets/TicketDetail';

export type ConnectedAddACommentProps = {|
    ticket : TicketDetail,
    stateSelector : (store : any) => AddACommentState & ComponentId,
|};

export type AddACommentDispatchProps = {
    onChangeValue : (val : string, componentId : string) => void,
};

export type AddACommentStatefulProps = $Diff<AddACommentProps,AddACommentDispatchProps>;

function mapStateToProps(store : any, ownProps : ConnectedAddACommentProps) : AddACommentStatefulProps {
    const state = ownProps.stateSelector(store);
    return {
        commentModel : state,
        ticket : ownProps.ticket,
        componentId : state.componentId,
    };
}

const mapDispatchToProps = {
    onChangeValue: updateComponentTextValue,
};

const connectedAddAComment = connect<AddACommentProps,ConnectedAddACommentProps, any, any, any, any>(
    mapStateToProps,
    mapDispatchToProps
)(AddAComment);
export { connectedAddAComment as ConnectedAddAComment };
//@flow
import * as React from "react";
import type { AddACommentState } from './AddACommentState';
import type { ComponentId } from 'models';
import TicketDetail from 'models/tickets/TicketDetail';

export type CommentProps = {
    commentModel : AddACommentState,
    ticket : TicketDetail,
};

export type AddACommentProps = ComponentId & CommentProps & {
    onChangeValue : (val : string, componentId : string) => void,
};

export function AddAComment(props : AddACommentProps) {

    function onChange(ev : SyntheticEvent<HTMLInputElement>) {
        props.onChangeValue(ev.currentTarget.value, props.componentId);
    }

    return (
        <form className="add_a_comment" id="new_comment" action="Comment/Add" method="post">
            <fieldset>
                <input type="hidden" name="TicketId" value={props.ticket.id} />
                <div className="form_element field long_text">
                    <label htmlFor="AddCommentBody">Body</label>
                    <textarea id="AddCommentBody"
                              name="Body"
                              onChange={onChange}
                              value={props.commentModel?.commentBody}></textarea>
                </div>
                <CommentFeedback commentModel={props.commentModel} ticket={props.ticket} />
                <div className="form_element button">
                    <button id="AddCommentSubmit">Submit</button>
                </div>
            </fieldset>
        </form>
    );
}

function CommentFeedback(props : CommentProps) {
    if(props.commentModel?.showInvalidCommentMessage) {
        return (
            <div className="form_element feedback warning AddCommentFeedbackMessage">
                <p>Please enter a comment.</p>
            </div>
        );
    }

    if(props.commentModel?.showSuccessMessage) {
        return (
            <div className="form_element feedback success AddCommentFeedbackMessage">
                <p>Your comment was added.</p>
            </div>
        );
    }

    return null;
}
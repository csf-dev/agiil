//@flow
import * as React from "react";
import TicketDetail from 'models/tickets/TicketDetail';
import TicketComment from 'models/tickets/TicketComment';

export function CommentsList(props : {| ticket : TicketDetail |})  {
    //$FlowFixMe
    const commentsMarkup = props.ticket.comments?.map(CommentsListItem);
    
    return (
        <ol className="comment_list">
            {commentsMarkup}
        </ol>
    );
}

export function CommentsListItem(comment : TicketComment, idx : number) {
    const markup = { __html: comment.commentMarkup };
    return (
        <li key={idx}>
            <header>
                <p className="author_info">
                    <span className="presentationless_context">Written by</span>
                    <strong className="author_name">{comment.author}</strong>
                    <span className="presentationless_context">on</span>
                    <strong className="author_timestamp">{comment.createdTimestamp}</strong><span className="presentationless_context">.</span>
                </p>
                <CommentAdminTools comment={comment} />
            </header>
            <div className="comment_content markdown_rendered_text"
                 dangerouslySetInnerHTML={markup} />
        </li>
    );
}

export function CommentAdminTools(props : { comment : TicketComment }) {
    return (
        <ul className="comment_admin">
            <EditComment comment={props.comment} />
            <DeleteComment comment={props.comment} />
        </ul>
    );
}

function EditComment(props : { comment : TicketComment }) {
    if(!props.comment.canEdit) return null;

    return (
        <li>
            <a  href={props.comment.editUrl}
                className="edit_comment"
                title="Edit this comment"><span>Edit this comment</span></a>
        </li>
    );
}

function DeleteComment(props : { comment : TicketComment }) {
    if(!props.comment.canDelete) return null;
    
    return (
        <li>
            <form method="post" action="Comment/ConfirmDelete" >
                <fieldset>
                    <input type="hidden" name="id" value={props.comment.id} />
                    <button className="delete_comment"
                            title="Delete this comment"><span>Delete this comment</span></button>
                </fieldset>
            </form>
        </li>
    );
}
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
                <p>
                    Written by <strong className="author_name">{comment.author}</strong> on
                    <strong className="author_timestamp">{comment.createdTimestamp}</strong>.
                </p>
                <CommentAdminTools comment={comment} />
            </header>
            <div className="comment_content markdown_rendered_text"
                 dangerouslySetInnerHTML={markup} />
        </li>
    );
}

export function CommentAdminTools(props : { comment : TicketComment }) {
    if(!props.comment.isMine) return null;

    return (
        <>
            <p>
                <a href={props.comment.editUrl} className="edit_comment">Edit this comment</a>
            </p>
            <form method="post" action="Comment/ConfirmDelete" >
                <fieldset>
                    <input type="hidden" name="id" value={props.comment.id} />
                    <button className="delete_comment">Delete this comment</button>
                </fieldset>
            </form>
        </>
    );
}
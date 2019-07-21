//@flow
import * as React from "react";

export function TicketDescription(props : { markup : string }) {
    const markup = { __html: props.markup };

    return (
        <div className="markdown_rendered_text description_content"
             dangerouslySetInnerHTML={markup} />
    );
}
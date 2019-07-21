//@flow
import type { ComponentId } from 'models';

export type AddACommentState = ComponentId & {
    commentBody : string,
    showSuccessMessage : bool,
    showInvalidCommentMessage : bool,
};
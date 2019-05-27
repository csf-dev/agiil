//@flow

const
    Info : 'INFO_FEEDBACK_MESSAGE' = 'INFO_FEEDBACK_MESSAGE',
    Success : 'SUCCESS_FEEDBACK_MESSAGE' = 'SUCCESS_FEEDBACK_MESSAGE',
    Failure : 'FAILURE_FEEDBACK_MESSAGE' = 'FAILURE_FEEDBACK_MESSAGE',
    Warning : 'WARNING_FEEDBACK_MESSAGE' = 'WARNING_FEEDBACK_MESSAGE',
    Error : 'ERROR_FEEDBACK_MESSAGE' = 'ERROR_FEEDBACK_MESSAGE';

export const messageType = {
    info : Info,
    success : Success,
    failure : Failure,
    warning : Warning,
    error : Error
};

export type FeedbackMessageType = $Values<typeof messageType>;

export type FeedbackMessage = {
    type : FeedbackMessageType,
    message : string,
};
//@flow
export type Label = {
    name : string,
    openTickets? : number,
    closedTickets? : number
}

export type SelectableLabel = Label & {
    selected : bool
}
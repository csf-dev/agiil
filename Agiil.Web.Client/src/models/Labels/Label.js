//@flow

export type Label = {
    name : string,
    openTickets? : number,
    closedTickets? : number
}

export type RemovableLabel = Label & {
    selectedForRemoval : bool
}
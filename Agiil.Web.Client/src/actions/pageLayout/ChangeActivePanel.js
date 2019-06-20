//@flow
import type { Action } from 'models';
import type { PanelName } from 'components/pageLayout';
import type { MovePanelType } from 'components/pageLayout/ToggleablePanels';
import { MoveLeft as Left, MoveRight as Right } from 'components/pageLayout/ToggleablePanels';
import type { AnyAction } from 'models';
import { Subject } from 'rxjs';
import { debounceTime } from 'rxjs/operators';
import type { Dispatch } from 'redux';

const
    MoveLeft : 'MOVE_LEFT' = 'MOVE_LEFT',
    MoveRight : 'MOVE_RIGHT' = 'MOVE_RIGHT',
    SetPanel : 'SET_PANEL' = 'SET_PANEL',
    OpenChangePanelDialog : 'OPEN_CHANGE_PANEL_DIALOG' = 'OPEN_CHANGE_PANEL_DIALOG',
    CloseChangePanelDialog : 'CLOSE_CHANGE_PANEL_DIALOG' = 'CLOSE_CHANGE_PANEL_DIALOG',
    PanelRecentlyChanged : 'PANEL_RECENTLY_CHANGED' = 'PANEL_RECENTLY_CHANGED',
    PanelNotRecentlyChanged : 'PANEL_NOT_RECENTLY_CHANGED' = 'PANEL_NOT_RECENTLY_CHANGED';

export { MoveLeft, MoveRight, SetPanel, PanelRecentlyChanged, PanelNotRecentlyChanged };

export type MovePanelsLeftAction = Action<typeof MoveLeft,{||},{||}>;
export type MovePanelsRightAction = Action<typeof MoveRight,{||},{||}>;
export type SetPanelAction = Action<typeof SetPanel,{ panelName : PanelName },{||}>;
export type OpenChangePanelDialogAction = Action<typeof OpenChangePanelDialog,{||},{||}>;
export type CloseChangePanelDialogAction = Action<typeof CloseChangePanelDialog,{||},{||}>;
export type PanelsRecentlyChangedAction = Action<typeof PanelRecentlyChanged,{||},{||}>;
export type PanelsNotRecentlyChangedAction = Action<typeof PanelNotRecentlyChanged,{||},{||}>;

const recentChange = new Subject<Dispatch<AnyAction>>();

recentChange.subscribe((next : Dispatch<AnyAction>) => {
    next({type: PanelRecentlyChanged, payload: {}});
});

recentChange
    .pipe(debounceTime(3000))
    .subscribe((next : Dispatch<AnyAction>) => {
        next({type: PanelNotRecentlyChanged, payload: {}});
    });

export function movePanels(direction : MovePanelType) {
    return (dispatch : Dispatch<AnyAction>) => {
        switch(direction) {
        case Left:
            dispatch({type: MoveLeft, payload: {}});
            break;
        case Right:
            dispatch({type: MoveRight, payload: {}});
            break;
        }

        recentChange.next(dispatch);
    }
}

export function openChangePanelDialog() {
    return {type: OpenChangePanelDialog, payload: {}};
}

export function closeChangePanelDialog() {
    return {type: CloseChangePanelDialog, payload: {}};
}

export function chooseNewPanelFromDialog(name : PanelName) {
    return (dispatch : Dispatch<AnyAction>) => {
        dispatch({type: SetPanel, payload: {panelName: name}});
        recentChange.next(dispatch);
        dispatch(closeChangePanelDialog());
    }
}
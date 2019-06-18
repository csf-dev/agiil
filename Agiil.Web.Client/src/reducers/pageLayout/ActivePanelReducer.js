//@flow
import { buildObjectReducer } from 'util/redux/ReducerBuilder';
import type { ActivePagePanel } from 'models/pageLayout';
import { NavigationPanel, MainPanel, AsidesPanel } from "components/pageLayout";
import type { PanelName } from "components/pageLayout";
import { MoveLeft, MoveRight, PanelRecentlyChanged, PanelNotRecentlyChanged } from 'actions/pageLayout/ChangeActivePanel';
import type { MovePanelsLeftAction, MovePanelsRightAction, PanelsRecentlyChangedAction, PanelsNotRecentlyChangedAction } from 'actions/pageLayout/ChangeActivePanel';
import type { Reducer } from 'redux';
import type { AnyAction } from 'models';

const defaultState = {
    activePanel : MainPanel,
    recentlyChanged : false,
};

function getDefaultState(s : ?ActivePagePanel) : ActivePagePanel {
    return {...defaultState, ...s};
};

function getLeftHandPanel(current : PanelName) {
    switch(current) {
    case NavigationPanel:
        return NavigationPanel;
    case AsidesPanel:
        return MainPanel;
    case MainPanel:
    default:
        return NavigationPanel;
    }
}

function getRightHandPanel(current : PanelName) {
    switch(current) {
    case NavigationPanel:
        return MainPanel;
    case AsidesPanel:
        return AsidesPanel;
    case MainPanel:
    default:
        return AsidesPanel;
    }
}
const reducer : Reducer<ActivePagePanel,AnyAction> = buildObjectReducer<ActivePagePanel>(getDefaultState)
    .forTypeKey(MoveLeft).andAction<MovePanelsLeftAction>((s, a) => {
        s = getDefaultState(s);
        return {...s, activePanel: getLeftHandPanel(s.activePanel)};
    })
    .forTypeKey(MoveRight).andAction<MovePanelsRightAction>((s, a) => {
        s = getDefaultState(s);
        return {...s, activePanel: getRightHandPanel(s.activePanel)};
    })
    .forTypeKey(PanelRecentlyChanged).andAction<PanelsRecentlyChangedAction>((s, a) => {
        s = getDefaultState(s);
        return {...s, recentlyChanged: true};
    })
    .forTypeKey(PanelNotRecentlyChanged).andAction<PanelsNotRecentlyChangedAction>((s, a) => {
        s = getDefaultState(s);
        return {...s, recentlyChanged: false};
    })
    .build();
export { reducer as ActivePanelReducer };
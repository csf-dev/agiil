//@flow
import type { PanelName } from 'components/pageLayout';

export type ActivePagePanel = {
    activePanel : PanelName,
    recentlyChanged : bool,
    choosePanelDialogVisible : bool,
};
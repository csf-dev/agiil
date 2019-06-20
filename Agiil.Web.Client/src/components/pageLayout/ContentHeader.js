//@flow
import * as React from "react";
import type { HasChildren } from 'components';
import { ChangePanelButton, CurrentPanelButton, MoveLeft, MoveRight } from './ToggleablePanels';

export function ContentHeader(props : HasChildren) {
    return (
        <header className="content_header">
            <CurrentPanelButton />
            {props.children}
            <ChangePanelButton type={MoveLeft} />
            <ChangePanelButton type={MoveRight} />
        </header>
    );
}

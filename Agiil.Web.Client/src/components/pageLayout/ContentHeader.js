//@flow
import * as React from "react";
import type { HasChildren } from 'components';
import { ChangePanelButton, MoveLeft, MoveRight } from './ToggleablePanels';

export function ContentHeader(props : HasChildren) {
    return (
        <header className="content_header">
            {props.children}
            <ChangePanelButton type={MoveLeft} />
            <ChangePanelButton type={MoveRight} />
        </header>
    );
}

//@flow
import React from 'react';
import ReactDOM from 'react-dom';
import { ModalBackground } from './ModalBackground';
import { ModalContainer } from './ModalContainer';
import type { HasChildren } from 'components/common';
import { getModalHost } from './getModalHost';

const Narrow : 'narrow' = 'narrow', Medium : 'medium' = 'medium', Wide : 'wide' = 'wide';
export { Narrow, Medium, Wide };

export type ModalWidth = typeof Narrow | typeof Medium  | typeof Wide;

export type ModalWindowProps = HasChildren & {
    visible : bool,
    width: ModalWidth,
};

export function ModalWindow(props : ModalWindowProps) {
    if(!props.visible) return null;

    const host = getModalHost();
    const content = getModalContent(props);

    return ReactDOM.createPortal(content, host);
}

function getModalContent(props : ModalWindowProps) {
    return (
        <>
            <ModalBackground />
            <ModalContainer width={props.width}>
                {props.children}
            </ModalContainer>
        </>
    );
}
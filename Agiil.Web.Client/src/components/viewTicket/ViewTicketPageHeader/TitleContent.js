//@flow
import * as React from "react";

export type TitleContentProps = {
    title : string
};

export function TitleContent(props : TitleContentProps) {
    return (<h1 className="title_content">{props.title}</h1>);
}
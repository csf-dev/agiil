//@flow
import * as React from "react";
import type { RemovableLabel } from '../../models/Labels/Label';
import SelectedLabel from './SelectedLabel';

type Props = {
    labels : Array<RemovableLabel>,
    onRemove : (label : RemovableLabel) => void
};

function getLabelsMarkupMapper(props : Props) {
    return (label : RemovableLabel) => mapLabelToMarkup(label, props);
}

function mapLabelToMarkup(label : RemovableLabel, props : Props) {
    const remover = () => props.onRemove(label);
    return <SelectedLabel label={label} onRemove={remover} key={label.name} />;
}

export default function SelectedLabelList(props : Props) {
    const labelMapper = getLabelsMarkupMapper(props);

    return (
        <ul className="SelectedLabelList">
            {props.labels.map(labelMapper)}
        </ul>
    );
}


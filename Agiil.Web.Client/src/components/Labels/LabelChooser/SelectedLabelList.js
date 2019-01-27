//@flow
import * as React from "react";
import type { SelectableLabel } from '../../../domain/Labels/Label';
import SelectedLabel from './SelectedLabel';
// $FlowFixMe
import styles from './LabelChooser.scss';

type Props = {
    labels : Array<SelectableLabel>,
    onRemove : (label : SelectableLabel) => void
};

export default function SelectedLabelList(props : Props) {
    return (
        <ul className={styles.SelectedLabels || 'SelectedLabels'}>
            {getLabels(props)}
        </ul>
    );
}

function getLabels(props : Props) {
    return props.labels.map(getLabelsMarkupMapper(props));
}

function getLabelsMarkupMapper(props : Props) {
    return (label : SelectableLabel) => {
        const remover = () => props.onRemove(label);
        return <SelectedLabel label={label} onRemove={remover} key={label.name} />;
    }
}

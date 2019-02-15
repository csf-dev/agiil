//@flow
import type { SelectableLabel } from 'models/labels';
import { GetsLabelList } from './GetsLabelList';

export class LabelListFromCommaSeparatedValuesCreator implements GetsLabelList {
    #commaSeparatedLabelNames : ?string;

    getLabelList() : Array<SelectableLabel> {
        const names = this.#commaSeparatedLabelNames;
        if(!names || !names.trim()) return [];

        return names
            .split(',')
            .map(x => x.trim())
            .filter(x => x)
            .map(x => ({ name: x, selected: false }));
    }

    constructor(commaSeparatedLabelNames : ?string) {
        this.#commaSeparatedLabelNames = commaSeparatedLabelNames;
    }
}

export default function getLabelListFactory(commaSeparatedLabelNames : ?string) : GetsLabelList {
    return new LabelListFromCommaSeparatedValuesCreator(commaSeparatedLabelNames);
}
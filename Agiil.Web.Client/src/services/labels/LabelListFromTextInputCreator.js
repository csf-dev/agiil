//@flow
import type { SelectableLabel } from 'models/labels';
import { GetsLabelList } from './GetsLabelList';
import getListFromStringProviderFactory from './LabelListFromCommaSeparatedValuesCreator';

export class LabelListFromTextInputCreator implements GetsLabelList {
    #input : HTMLInputElement;
    #fromStringProviderFactory : (x : string) => GetsLabelList;

    getLabelList() : Array<SelectableLabel> {
        const factory = this.#fromStringProviderFactory;
        return factory(this.#input.value).getLabelList();
    }

    constructor(input : HTMLInputElement, fromStringProviderFactory : (x : ?string) => GetsLabelList) {
        this.#input = input;
        this.#fromStringProviderFactory = fromStringProviderFactory;
    }
}

export default function getLabelListFactory(input : HTMLInputElement) : GetsLabelList {
    return new LabelListFromTextInputCreator(input, getListFromStringProviderFactory);
}
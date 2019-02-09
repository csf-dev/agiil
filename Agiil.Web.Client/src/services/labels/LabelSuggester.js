//@flow
import { RequestsDataAsync } from 'services';
import type { Label } from 'models/labels';
import { SendsNetworkRequests, requestServiceFactory } from '../../network'
import type { Cancelable } from 'models';

type LabelsQuery = { q : string };

export class LabelSuggester implements RequestsDataAsync<string,Array<Label>> {
    net : SendsNetworkRequests<LabelsQuery,Array<Label>>;

    getDataAsync(request : string) : Cancelable<Array<Label>> {
        return this.net.sendRequest({ q: request});
    }

    constructor(net : SendsNetworkRequests<LabelsQuery,Array<Label>>) {
        this.net = net;
    }
}

export default function getLabelSuggester() : RequestsDataAsync<string,Array<Label>> {
    const net = requestServiceFactory.getJson<LabelsQuery,Array<Label>>('Labels');
    return new LabelSuggester(net);
}
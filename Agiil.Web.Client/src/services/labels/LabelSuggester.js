//@flow
import { RequestsDataAsync } from 'services';
import type { Label } from 'models/labels';
import { SendsNetworkRequests, requestServiceFactory } from 'network'
import type { Cancelable } from 'models';

type LabelsQuery = { q : string };

type LabelDto = {
    Name : string;
    CountOfOpenTickets : number;
    CountOfClosedTickets : number;
}

export class LabelSuggester implements RequestsDataAsync<string,Array<Label>> {
    net : SendsNetworkRequests<LabelsQuery,Array<LabelDto>>;

    getDataAsync(request : string) : Cancelable<Array<Label>> {
        return this.net
            .sendRequest({ q: request})
            .map(labels => {
                return labels.map(labelDto => ({
                    name : labelDto.Name,
                    openTickets : labelDto.CountOfOpenTickets,
                    closedTickets : labelDto.CountOfClosedTickets
                }));
            });
    }

    constructor(net : SendsNetworkRequests<LabelsQuery,Array<LabelDto>>) {
        this.net = net;
    }
}

export default function getLabelSuggester() : RequestsDataAsync<string,Array<Label>> {
    const net = requestServiceFactory.getJson<LabelsQuery,Array<LabelDto>>('Labels');
    return new LabelSuggester(net);
}
//@flow
import type { Observable } from 'rxjs';
import type { GetsScrolling } from './GetsScrolling';
import type { GetsScrollFrames } from './GetsScrollFrames';
import type { ScrollFrame } from './ScrollFrame';
import type { ElementScrollInfoMap, CumulativeScrollInfo } from './ElementScrollInfoMap';
import { scan, startWith } from 'rxjs/operators';

export class ScrollingProvider implements GetsScrolling {
    #framesProvider : GetsScrollFrames;

    getScrolling() : Observable<ElementScrollInfoMap> {
        const
            seed : ElementScrollInfoMap = { map: new Map() },
            scrollFrames = this.#framesProvider.getScrollFrames();

        return scrollFrames.pipe(
            scan(reduceScrollFrame, seed),
            startWith({ ...seed })
        );
    }

    constructor(framesProvider : GetsScrollFrames) {
        this.#framesProvider = framesProvider;
    }
}

function reduceScrollFrame(acc : ElementScrollInfoMap, next : ScrollFrame) : ElementScrollInfoMap {
    const
        element = next.scrolledElement,
        cumulativeInfo = getOrAddCumulativeScrollInfo(acc.map, element);

    cumulativeInfo.vector.x = element.scrollLeft - cumulativeInfo.start.x;
    cumulativeInfo.vector.y = element.scrollTop - cumulativeInfo.start.y;
    return { ...acc };
}

function getOrAddCumulativeScrollInfo(map : Map<HTMLElement, CumulativeScrollInfo>, element : HTMLElement) : CumulativeScrollInfo {
    //$FlowFixMe
    if(map.has(element)) return map.get(element);

    const elementInfo = createCumulativeInfoForElement(element);
    map.set(element, elementInfo);
    return elementInfo;
}

const createCumulativeInfoForElement : (element : HTMLElement) => CumulativeScrollInfo
    = element => ({
        scrolledElement: element,
        start: { x: element.scrollLeft, y: element.scrollTop },
        vector: { x: 0, y: 0 },
    });
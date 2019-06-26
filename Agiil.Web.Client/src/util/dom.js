//@flow

export function getElementByIdMandatory(id : string) {
    const element = document.getElementById(id);
    if(!element) throw new Error(`Element '#${id}' expected but was not found`);
    return element;
}

export interface CanGetElementByQuery {
    querySelector(query : string) : ?HTMLElement
};

export function querySelectorMandatory(query : string, baseElement : CanGetElementByQuery = document) {
    const element = baseElement.querySelector(query);
    if(!element) throw new Error(`Element matching '#${query}' expected but was not found`);
    return element;
}

export type DangerousInnerHtml = {
    __html : string
};

export function getElementsHtml(elements : ?Array<HTMLElement>) : DangerousInnerHtml {
    if(!elements) return { __html: '' };

    const markup = elements
        .map(x => x.outerHTML)
        .reduce((acc, val) => acc + val, '');
    
    return { __html: markup };
}
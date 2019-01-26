//@flow

export function getDocElement() {
    if(!document.documentElement) throw new Error('Document element missing');
    return document.documentElement;
}

export function getElementByIdMandatory(id : string) {
    const element = document.getElementById(id);
    if(!element) throw new Error(`Element #${id} missing`);
    return element;
}

export function getTestDom() {
    const testDom = document.createElement('div');
    getDocElement().appendChild(testDom);
    return testDom;
}
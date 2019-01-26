//@flow

export function getDocElement() {
    if(!document || !document.documentElement) throw new Error('Document element missing');
    return document.documentElement;
}

export function getTestDom() {
    const testDom = document.createElement('div');
    getDocElement().appendChild(testDom);
    return testDom;
}
//@flow

export function getDocElement() {
    if(!document.documentElement) throw new Error('Document element missing');
    return document.documentElement;
}

export const testDomId = 'TestRoot';

export function getTestDom() {
    const testDom = document.createElement('div');
    testDom.id = testDomId;
    getDocElement().appendChild(testDom);
    return testDom;
}
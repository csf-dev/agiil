//@flow

export function getElementByIdMandatory(id : string) {
    const element = document.getElementById(id);
    if(!element) throw new Error(`Element '#${id}' expected but was not found`);
    return element;
}
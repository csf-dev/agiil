//@flow
import { getElementByIdMandatory } from 'util/dom';

export function getModalHost() {
    return getElementByIdMandatory('modalHost');
}
//@flow

export default function mandatory<T>(maybe : T | null | void) : T {
    if(maybe === null) throw new Error('Value expected but got a null reference');
    if(maybe === undefined) throw new Error('Value expected but got undefined');
    return maybe;
}
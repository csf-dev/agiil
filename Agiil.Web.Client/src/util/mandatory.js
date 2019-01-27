//@flow

export default function mandatory<T>(maybe : ?T) : T {
    if(maybe === null) throw new Error('`mandatory` requires an object but was passed a null reference');
    if(maybe === undefined) throw new Error('`mandatory` requires an object but was passed an undefined reference');
    return maybe;
}
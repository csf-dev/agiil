//@flow

/* This is a small shim for accessing Modernizr via WebPack modules.
 * I have decided to keep Modernizr as a global variable and not to
 * wrap it in a WebPack module.
 *
 * The reason for this is that I always want to execute it in the
 * <head> element and I want it unencumbered by WebPack concerns.
 *
 * I tried using a WebPack module once, but it lead to a FOUC, because
 * it forced Modernizr to execute later in the page lifetime in order
 * to "play nicely" with WebPack.
 */

type ModernizrTestSpec = string | {[key : string] : () => bool};

export type ModernizrApi = {
    on : (feature : string, callback : () => void) => void,
    addTest : (feature : ModernizrTestSpec, test? : () => bool) => void,
    atRule : (ruleName : string) => bool,
    _domPrefixes : Array<string>,
    hasEvent : (eventName : string, element? : any) => bool,
    mq : (query : string) => bool,
    prefixed : (prop : string, obj? : any, getString? : bool) => string | () => void,
    prefixedCSS : (prop : string) => string,
    prefixedCSSValue : (prop : string, value : string) => string,
    _prefixes : Array<string>,
    testAllProps : (prop : string, value? : string, skipValueTest? : bool) => bool,
    testProp : (prop : string, value? : string, useValue? : bool) => bool,
    testStyles : (rule : string, callback : (ele : HTMLElement, rule : string) => void, nodes? : number, testnames? : Array<string>) => void,
    has : (test : string) => bool,
}

//$FlowFixMe
Modernizr.has = function(test : string) { return this[test]; }

//$FlowFixMe
export const modernizr : ModernizrApi = Modernizr;

const
    possibletouchscreen = 'possibletouchscreen',
    pointermediaquery = 'pointermq',
    touchevents = 'touchevents',
    passiveeventlisteners = 'passiveeventlisteners';

const tests = {
    possibletouchscreen,
    pointermediaquery,
    touchevents,
    passiveeventlisteners
};
Object.freeze(tests);

export { tests };
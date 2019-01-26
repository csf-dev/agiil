//@flow

export function getUrlWithQuerystringParams(url : string, params? : {}) {
    if(!params) return url;

    // Url might already include a querystring, in which case we're just adding more
    const separatorChar = url.includes('?')? '&' : '?';
    const encodedParams = encodeAsQuerystringParams(params);
    
    if(!encodedParams.length) return url;
    return url + separatorChar + encodedParams;
}

export function encodeAsQuerystringParams(params : {}) {
    const encoded = [];

    for(const key in params) {
        if(!params.hasOwnProperty(key)) continue;

        const val : any = params[key];
        encoded.push(`${encodeURIComponent(key)}=${encodeURIComponent(val)}`)
    }

    return encoded.join('&');
}
const fileMatcher = require('glob');

function getFilenames(pattern, opts) {
    return new Promise((res, rej) => fileMatcher.glob(pattern, opts, (err, filenames) => res(filenames)));
}

module.exports = getFilenames;
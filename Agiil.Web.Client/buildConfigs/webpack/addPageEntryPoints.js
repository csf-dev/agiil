const getFilenames = require('./getFilenames');

async function addPageEntryPoints(webpackConfig) {
    webpackConfig.entry = webpackConfig.entry || {};

    const pages = await getPages();
    pages.forEach(x => {
        webpackConfig.entry[x.name] = './' + x.path;
    });
}

async function getPages() {
    const filenames = await getFilenames('src/pages/*.js');
    return filenames.map(x => {
        return { name: x.match(/([^/]+)\.js$/)[1], path: x };
    });
}

module.exports = addPageEntryPoints;
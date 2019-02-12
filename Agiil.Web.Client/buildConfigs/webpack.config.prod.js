const webpackConfig = require('./webpack/getCommonConfig')();
const addPageEntryPoints = require('./webpack/addPageEntryPoints');
const configureProdOutputFilenames = require('./webpack/configureProdOutputFilenames');
const addMiniCssPluginAndLoader = require('./webpack/addMiniCssPluginAndLoader');
const addHtmlPlugin = require('./webpack/addHtmlPlugin');

webpackConfig.mode = 'production';

module.exports = new Promise(async (res, rej) => {
    addMiniCssPluginAndLoader(webpackConfig);
    await addPageEntryPoints(webpackConfig);
    // HTML plugin must be executed after entry points added
    addHtmlPlugin(webpackConfig);
    configureProdOutputFilenames(webpackConfig);
    res(webpackConfig);
});
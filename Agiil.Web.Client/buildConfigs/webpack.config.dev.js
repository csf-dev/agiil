const webpackConfig = require('./webpack/getCommonConfig')();
const addPageEntryPoints = require('./webpack/addPageEntryPoints');
const addTestHarnessEntrypoints = require('./webpack/addTestHarnessEntrypoints');
const addMiniCssPluginAndLoader = require('./webpack/addMiniCssPluginAndLoader');
const addHtmlPlugin = require('./webpack/addHtmlPlugin');

webpackConfig.mode = 'development';

module.exports = new Promise(async (res, rej) => {
    addMiniCssPluginAndLoader(webpackConfig);
    // await addTestHarnessEntrypoints(webpackConfig);
    await addPageEntryPoints(webpackConfig);
    // HTML plugin must be executed after entry points added
    addHtmlPlugin(webpackConfig);
    res(webpackConfig);
});

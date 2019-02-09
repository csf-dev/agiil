const webpackConfig = require('./webpack/getCommonConfig')();
const addPageEntryPoints = require('./webpack/addPageEntryPoints');
const configureProdOutputFilenames = require('./webpack/configureProdOutputFilenames');
const addMiniCssPluginAndLoader = require('./webpack/addMiniCssPluginAndLoader');

webpackConfig.mode = 'production';

module.exports = new Promise(async (res, rej) => {
    addMiniCssPluginAndLoader(webpackConfig);
    configureProdOutputFilenames(webpackConfig);
    await addPageEntryPoints(webpackConfig);
    res(webpackConfig);
});
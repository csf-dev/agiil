const fileMatcher = require('glob');
const fs = require('fs');
const CopyWebpackPlugin = require('copy-webpack-plugin');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");

const webpackCommonConfig = require('./webpack.config.js');
const webpackConfig = Object.assign({}, webpackCommonConfig);

webpackConfig.mode = 'development';
webpackConfig.entry = {};
webpackConfig.plugins = webpackConfig.plugins || [];
webpackConfig.plugins.push(
    new CopyWebpackPlugin([ { from: './src/**/*.TestHarness.html', to: '.', flatten: true } ])
);
addMiniCssPluginAndLoader(webpackConfig);

module.exports = new Promise(async (res, rej) => {
    await addTestHarnessEntrypoints(webpackConfig);
    res(webpackConfig);
});

async function addTestHarnessEntrypoints(webpackConfig) {
    const testHarnesses = await getTestHarnesses();
    testHarnesses.forEach(x => {
        webpackConfig.entry[x.name + '.TestHarness'] = './' + x.path;
    });
}

async function getTestHarnesses() {
    const filenames = await getFilenames('src/**/*.TestHarness.js');
    return filenames.map(x => {
        return { name: x.match(/([^/]+)\.TestHarness\.js$/)[1], path: x };
    });
}

function getFilenames(pattern, opts) {
    return new Promise(function(res, rej) {
        fileMatcher.glob(pattern, opts, function(err, filenames) {
            res(filenames);
        });
    });
}

function addMiniCssPluginAndLoader(webpackConfig) {
    webpackConfig.plugins.push(new MiniCssExtractPlugin());

    webpackConfig.module.rules
        .filter(x => x.use.includes('sass-loader'))
        .forEach(x => x.use.unshift(MiniCssExtractPlugin.loader));
}
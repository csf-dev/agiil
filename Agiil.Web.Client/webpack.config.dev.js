const fileMatcher = require('glob');
const fs = require('fs');
const CopyWebpackPlugin = require('copy-webpack-plugin');

const webpackCommonConfig = require('./webpack.config.js');
const webpackConfig = Object.assign({}, webpackCommonConfig);

webpackConfig.mode = 'development';
webpackConfig.plugins.push(
    new CopyWebpackPlugin([ { from: './src/**/*.TestHarness.html', to: '.', flatten: true } ])
);

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

module.exports = new Promise(async (res, rej) => {
    const testHarnesses = await getTestHarnesses();
    testHarnesses.forEach(x => {
        webpackConfig.entry[x.name + '.TestHarness'] = './' + x.path;
    });
    res(webpackConfig);
});



const getFilenames = require('./getFilenames');
const CopyWebpackPlugin = require('copy-webpack-plugin');

async function addTestHarnessEntrypoints(webpackConfig) {
    webpackConfig.entry = webpackConfig.entry || {};

    const testHarnesses = await getTestHarnesses();
    testHarnesses.forEach(x => {
        webpackConfig.entry[x.name + '.TestHarness'] = './' + x.path;
    });

    webpackConfig.plugins = webpackConfig.plugins || [];
    webpackConfig.plugins.push(
        new CopyWebpackPlugin([ { from: './src/**/*.TestHarness.html', to: '.', flatten: true } ])
    );
}

async function getTestHarnesses() {
    const filenames = await getFilenames('src/**/*.TestHarness.js');
    return filenames.map(x => {
        return { name: x.match(/([^/]+)\.TestHarness\.js$/)[1], path: x };
    });
}

module.exports = addTestHarnessEntrypoints;
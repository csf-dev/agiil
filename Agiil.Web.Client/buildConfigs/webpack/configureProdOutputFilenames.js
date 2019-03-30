module.exports  = function configureProdOutputFilenames(webpackConfig) {
    webpackConfig.output = webpackConfig.output || {};
    webpackConfig.output.filename = '[name].[contenthash].js';
}
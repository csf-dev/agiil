const HtmlPlugin = require("html-webpack-plugin");

module.exports = function addHtmlPlugin(webpackConfig) {
    webpackConfig.plugins = webpackConfig.plugins || [];

    const entryPointNames = Object.entries(webpackConfig.entry).map(x => x[0]);
    const htmlFileMapper = getHtmlFileMapper(entryPointNames);
    const htmlPlugins =  entryPointNames.map(htmlFileMapper);
    webpackConfig.plugins.push(...htmlPlugins);
}

function getHtmlFileMapper(entryPointNames) {
    return entryPoint => {
        const otherEntryPoints = entryPointNames.filter(name => name != entryPoint);

        return new HtmlPlugin({
            filename: '../../' + entryPoint + '.html',
            excludeChunks: otherEntryPoints,
            minify: false,
            template: 'src/pages/outputPage.template._html',
            inject: false
        });
    };
}

const HtmlPlugin = require("html-webpack-plugin");

module.exports = function addHtmlPlugin(webpackConfig) {
    webpackConfig.plugins = webpackConfig.plugins || [];

    const pageEntryPointNames = Object.entries(webpackConfig.entry)
                                      .map(x => x[0])
                                      .filter(x => x != 'modernizr');

    addHtmlPluginsForPages(pageEntryPointNames, webpackConfig);
    addHtmlPluginForModernizr(webpackConfig);
}

function addHtmlPluginForModernizr(webpackConfig) {
    if(!webpackConfig.entry['modernizr']) return;

    webpackConfig.plugins.push(new HtmlPlugin({
        filename: '../../modernizr.html',
        minify: false,
        template: 'src/pages/modernizrPage.template._html',
        inject: false
    }));
}

function addHtmlPluginsForPages(entryPointNames, webpackConfig) {
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

const MiniCssExtractPlugin = require("mini-css-extract-plugin");

module.exports = function addMiniCssPluginAndLoader(webpackConfig) {
    webpackConfig.plugins = webpackConfig.plugins || [];
    webpackConfig.module.rules = webpackConfig.module.rules || [];

    webpackConfig.plugins.push(new MiniCssExtractPlugin());

    webpackConfig.module.rules
        .filter(x => x.use.includes('sass-loader'))
        .forEach(x => x.use.unshift(MiniCssExtractPlugin.loader));
}
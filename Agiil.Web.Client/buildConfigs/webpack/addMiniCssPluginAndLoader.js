const MiniCssExtractPlugin = require("mini-css-extract-plugin");

module.exports = function addMiniCssPluginAndLoader(webpackConfig) {
    webpackConfig.plugins = webpackConfig.plugins || [];
    webpackConfig.module.rules = webpackConfig.module.rules || [];

    const filenamePattern = (webpackConfig.mode == 'production')? '[name].[contenthash].css' : '[name].css';

    webpackConfig.plugins.push(new MiniCssExtractPlugin({
        filename: filenamePattern
    }));

    webpackConfig.module.rules
        .filter(x => x.use.includes('sass-loader'))
        .forEach(x => x.use.unshift(MiniCssExtractPlugin.loader));
}
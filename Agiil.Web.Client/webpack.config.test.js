const webpackCommonConfig = require('./webpack.config.js');
const webpackConfig = Object.assign({}, webpackCommonConfig);

webpackConfig.module.rules.push({
    test: /\.spec\.js$/,
    exclude: /(node_modules|bower_components)/,
    use: [ 'babel-loader' ]
});

module.exports = webpackConfig;
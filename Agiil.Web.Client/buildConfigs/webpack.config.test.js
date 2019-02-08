const webpackCommonConfig = require('./webpack.config.js');
const webpackConfig = Object.assign({}, webpackCommonConfig);

webpackConfig.mode = 'development';
webpackConfig.module.rules[1].use.unshift({loader: 'style-loader'});
webpackConfig.module.rules[2].use.unshift({loader: 'style-loader'});

module.exports = webpackConfig;
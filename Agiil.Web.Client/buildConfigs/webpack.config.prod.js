const webpackCommonConfig = require('./webpack.config.js');
const webpackConfig = Object.assign({}, webpackCommonConfig);

webpackConfig.mode = 'production';

module.exports = webpackConfig;
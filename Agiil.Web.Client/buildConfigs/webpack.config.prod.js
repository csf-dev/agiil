const webpackCommonConfig = require('./webpack.config.js');
const webpackConfig = Object.assign({}, webpackCommonConfig);

webpackConfig.mode = 'production';
webpackConfig.entry = webpackConfig.entry || {};
webpackConfig.entry.LabelChooser = './src/components/Labels/LabelChooser/index.js'

module.exports = webpackConfig;
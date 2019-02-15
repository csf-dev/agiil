const webpackConfig = require('./webpack/getCommonConfig')();
const disableChunkSplitting = require('./webpack/disableChunkSplitting');

webpackConfig.mode = 'development';

webpackConfig.module.rules[1].use.unshift({loader: 'style-loader'});
webpackConfig.module.rules[2].use.unshift({loader: 'style-loader'});

disableChunkSplitting(webpackConfig);

module.exports = webpackConfig;
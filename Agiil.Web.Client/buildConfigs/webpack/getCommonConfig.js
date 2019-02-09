const webpackCommonConfig = require('../webpack.config.common.js');

module.exports = function getCommonConfig() {
    return Object.assign({}, webpackCommonConfig);
}

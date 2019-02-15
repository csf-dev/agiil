module.exports = function disableChunkSplitting(webpackConfig) {
    if(!webpackConfig.optimization) return;
    if(!webpackConfig.optimization.splitChunks) return;
    delete webpackConfig.optimization.splitChunks;
}
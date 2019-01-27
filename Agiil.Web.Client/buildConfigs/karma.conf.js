module.exports = function(config) {
  const webpackConfig = require('./webpack.config.test.js');
  const testFilePatterns = ['../src/**/*.spec.js'];
  
  config.set({
    basePath: '',
    frameworks: ['jasmine'],
    files: testFilePatterns.map(function(item) { return { pattern: item, watched: true }; }),
    preprocessors: (function(){
      let output = {};
      testFilePatterns.forEach(function(item) { output[item] = ['webpack']; });
      return output;
    })(),
    webpack: webpackConfig,
    reporters: ['spec'],
    port: 9876,
    colors: true,
    logLevel: config.LOG_WARN,
    autoWatch: true,
    browsers: ['ChromeHeadless'],
    singleRun: true,
    concurrency: Infinity,
    specReporter: {
        suppressSkipped: false,
        suppressPassed: true
    },
  });
}
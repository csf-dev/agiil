const path = require('path');

const cssModuleLoader = {
  loader: 'css-loader',
  options: {
    modules: true,
    localIdentName: '[local]__[hash:base64:5]'
  }
}

const cssPlainLoader = {
  loader: 'css-loader',
  options: {
    modules: false
  }
}

const webpackConfig = {
    resolve: {
        modules: [
            'node_modules',
            path.resolve(__dirname, '../src')
        ]
    },
    module: {
        rules: [
            {
                test: /\.js$/,
                exclude: /(node_modules|bower_components)/,
                use: [ 'babel-loader' ]
            },
            {
                test: /\.module\.scss$/,
                exclude: /(node_modules|bower_components)/,
                use: [
                    cssModuleLoader,
                    'sass-loader'
                ]
            },
            {
                test: /\.scss$/,
                exclude: /(node_modules|bower_components|\.module\.scss)/,
                use: [
                    cssPlainLoader,
                    'sass-loader'
                ]
            },
        ]
    },
    output: {
        path: path.resolve(__dirname, '../dist')
    },
    devtool: 'source-map'
};

module.exports = webpackConfig;
const path = require('path');

const cssModuleLoader = {
  loader: 'css-loader',
  options: {
    modules: true,
    localIdentName: '[local]__[hash:base64:5]',
    importLoaders: 1
  }
};

const cssPlainLoader = {
  loader: 'css-loader',
  options: {
    modules: false,
    importLoaders: 1
  }
};

const modernizrAliasFile = path.resolve(__dirname, './modernizr-alias.js');

const modernizrLoader = {
    loader: 'webpack-modernizr-loader',
    options: {
        "minify": true,
        "options": [ "setClasses" ],
        "feature-detects": [
            "test/touchevents",
            "test/css/flexbox",
            "test/mediaquery/pointermq"
        ]
    },
    test: modernizrAliasFile
}

const webpackConfig = {
    resolve: {
        modules: [
            'node_modules',
            path.resolve(__dirname, '../src'),
        ],
        alias: {
            modernizr$: modernizrAliasFile
        }
    },
    module: {
        rules: [
            {
                test: /\.js$/,
                exclude: [
                    path.resolve(__dirname, '../node_modules'),
                ],
                use: [
                    {
                        loader: 'babel-loader',
                        options: {
                            babelrc: false,
                            configFile: path.resolve(__dirname, '../babel.config.json')
                        }
                    }
                ]
            },
            {
                // Some node modules must be transpiled to work with my target browsers
                // See #AG294 for more info.  By default everything in node_modules is
                // transpiled, with only specific exceptions.
                test: /\.js$/,
                include: [
                    path.resolve(__dirname, '../node_modules'),
                ],
                exclude: [
                    path.resolve(__dirname, '../node_modules/core-js'),
                ],
                use: [
                    {
                        loader: 'babel-loader',
                        options: {
                            babelrc: false,
                            configFile: path.resolve(__dirname, '../babel.config.json'),
                            sourceType: 'unambiguous'
                        }
                    }
                ]
            },
            {
                test: /\.module\.scss$/,
                exclude: /(node_modules|bower_components)/,
                use: [
                    cssModuleLoader,
                    'postcss-loader',
                    'sass-loader'
                ]
            },
            {
                test: /\.scss$/,
                exclude: /(node_modules|bower_components|\.module\.scss)/,
                use: [
                    cssPlainLoader,
                    'postcss-loader',
                    'sass-loader'
                ]
            },
            {
                test: /\.(png|svg|jpg)$/,
                use: [ 'file-loader' ],
            },
        ]
    },
    output: {
        path: path.resolve(__dirname, '../dist/Content/bundles')
    },
    devtool: 'source-map',
    optimization: {
        splitChunks: {
            chunks: 'all',
            cacheGroups: {
                "babel-polyfill": {
                    test: /[\\/]node_modules[\\/](core-js|@babel)[\\/]/,
                    priority: 10,
                    enforce: true,
                    name: 'babel-polyfill.bundle',
                },
                "react-redux": {
                    test: /[\\/]node_modules[\\/](react(-dom|-redux|-is)?|redux(-thunk)?|prop-types|hoist-non-react-statics)[\\/]/,
                    priority: 10,
                    enforce: true,
                    name: 'react-redux.bundle',
                },
                "vendors": {
                    test: /[\\/]node_modules[\\/]/,
                    priority: 5,
                    enforce: true,
                    name: 'vendors.bundle',
                },
                "agiil-app": {
                    test: /[\\/]src[\\/](?!pages)/,
                    name: 'agiil-app',
                    minChunks: 2,
                    priority: 0,
                    minSize: 15360,
                    enforce: true,
                }
            },
        }
    }
};

module.exports = webpackConfig;
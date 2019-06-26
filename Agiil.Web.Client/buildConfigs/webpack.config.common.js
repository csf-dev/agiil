const path = require('path');

const cssModuleLoader = {
  loader: 'css-loader',
  options: {
    modules: true,
    localIdentName: '[local]__[hash:base64:5]'
  }
};

const cssPlainLoader = {
  loader: 'css-loader',
  options: {
    modules: false
  }
};

const webpackConfig = {
    resolve: {
        modules: [
            'node_modules',
            path.resolve(__dirname, '../src'),
        ]
    },
    module: {
        rules: [
            {
                test: /\.js$/,
                exclude: /(node_modules|bower_components)/,
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
                include: /node_modules/,
                exclude: [ /node_modules\/core-js/ ],
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
                    // TODO #AG236 - Add PostCSS here
                    cssModuleLoader,
                    'sass-loader'
                ]
            },
            {
                test: /\.scss$/,
                exclude: /(node_modules|bower_components|\.module\.scss)/,
                use: [
                    // TODO #AG236 - Add PostCSS here
                    cssPlainLoader,
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
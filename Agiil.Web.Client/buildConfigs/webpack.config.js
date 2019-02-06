const path = require('path');


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
                test: /\.scss$/,
                exclude: /(node_modules|bower_components)/,
                use: [
                    {
                        loader: 'css-loader',
                        options: {
                            modules: true,
                            localIdentName: '[local]__[hash:base64:5]'
                        }
                    },
                    // 'postcss-loader',
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
const path = require('path');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");


const webpackConfig = {
    plugins: [
        new MiniCssExtractPlugin(),
    ],
    entry: {},
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
                    MiniCssExtractPlugin.loader,
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
        path: path.resolve(__dirname, 'dist')
    },
    devtool: 'source-map'
};

module.exports = webpackConfig;
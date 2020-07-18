// These Modernizr configuration options are imported & used
// by Webpack during the build process.

module.exports = {
    "minify": true,
    "options": [ "setClasses" ],
    "feature-detects": [
        "test/touchevents",
        "test/css/flexbox",
        "test/mediaquery/pointermq"
    ]
}
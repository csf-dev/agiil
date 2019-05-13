// Script accepts a single parameter, and that's the type of build we are running
const spawn = require('child_process').spawn;

var options = getOptions();

buildModernizr(options)
    .then(() => runWebpack(options));

function getOptions() {
    let buildType = process.argv[2];
    let configFile, watched = false;

    switch(buildType)
    {
    case 'dev':
        configFile = 'buildConfigs/webpack.config.dev.js';
        break;

    case 'watchedDev':
        configFile = 'buildConfigs/webpack.config.dev.js';
        watched = true;
        break;

    case 'prod':
        configFile = 'buildConfigs/webpack.config.prod.js';
        break;

    default:
        throw new Error(`Unexpected build type: ${buildType}`);
    }

    return { configFile, watched };
}

function runWebpack(options) {
    const webpackArgs = ['webpack', '--config', options.configFile];
    if(options.watched) webpackArgs.push('-w');

    return new Promise((res, rej) => {
        const webpackProcess = spawn('npx', webpackArgs);
        webpackProcess.on('exit', (code) => {
            if(code == 0 || options.watched) res();
            else rej();
        });
    });
}

function buildModernizr(options) {
    const modernizrArgs = ['modernizr', '-c', 'buildConfigs/modernizr.config.json', '-d', 'dist/Content/bundles/modernizr.agiil.js'];

    return new Promise((res, rej) => {
        const modernizrProcess = spawn('npx', modernizrArgs);
        modernizrProcess.on('exit', (code) => {
            if(code == 0) res();
            else rej();
        });
    });
}
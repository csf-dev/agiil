// Script accepts a single parameter, and that's the type of build we are running
const spawn = require('child_process').spawn;

var options = getOptions();

buildModernizr(options)
    .then(() => runWebpack(options))
    .then(() => {}, (err) => { console.error('Unexpected error', err); process.exit(1); });

function getOptions() {
    const buildType = process.argv[2];
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
    const spawnOptions = {
        stdio: 'inherit',
        shell: os.platform() === 'win32'
    };

    return new Promise((res, rej) => {
        console.log(`Executing Webpack: npx ${webpackArgs.join(' ')}`);
        const webpackProcess = spawn('npx', webpackArgs, spawnOptions);
        
        webpackProcess.on('exit', (code) => {
            console.log('Completed webpack, exit code ' + code);
            if(code == 0 || options.watched) res();
            else rej('Webpack failed');
        });
    });
}

function buildModernizr(options) {
    const modernizrArgs = ['modernizr', '-c', 'buildConfigs/modernizr.config.json', '-d', 'dist/Content/bundles/modernizr.agiil.js'];
    const spawnOptions = {
        stdio: 'inherit',
        shell: os.platform() === 'win32'
    };

    return new Promise((res, rej) => {
        const modernizrProcess = spawn('npx', modernizrArgs, spawnOptions);
        console.log(`Executing Modernizr: npx ${modernizrArgs.join(' ')}`);
        
        modernizrProcess.on('exit', (code) => {
            console.log('Completed custom modernizr build, exit code ' + code);
            if(code == 0) res();
            else rej('Modernizr failed');
        });
    });
}
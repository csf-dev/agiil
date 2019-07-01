//@flow
import 'element-remove';
import getWindowErrorDetector from './WindowErrorDetector';
import showModalOnUnhandledError from './showModalOnUnhandledError';

// TODO: Fix this by importing Modernizr in the normal way
// This will probably require some WebPack config to make it
// into a module.
// $FlowFixMe
const modernizr = Modernizr;

function getStartupFunction(startup : () => void) : () => void {
    return () => {
        const errorDetector = getWindowErrorDetector();
        errorDetector.addUnhandledErrorHandler(showModalOnUnhandledError);
        configureModernizr();

        if(!modernizr.flexbox) {
            console.log('Not loading client scripts; we are in an ancient browser which does not does not support the baseline requirements.');
            return;
        }

        startup();
    };
}

function pageStarter(startup : () => void) {
    let started = false;
    const startupFunc = getStartupFunction(startup);

    // Event handler for when the page loads
    document.addEventListener("DOMContentLoaded", () => {
        if(started) return;
        startupFunc();
        started = true;
    });

    // In case the page is already loaded
    if(!started && document.readyState !== 'loading') {
        startupFunc();
        started = true;
    }
}

function configureModernizr() {
    modernizr.addTest({
        'possibletouchscreen': function() {
            if(!modernizr.pointermq) return false;
            if(!modernizr.touchevents) return false;
            return window.matchMedia('(pointer: coarse)').matches;
        }
    });
}

export default pageStarter;

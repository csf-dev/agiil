//@flow
import 'element-remove';
import getWindowErrorDetector from './WindowErrorDetector';
import showModalOnUnhandledError from './showModalOnUnhandledError';
import { modernizr } from './modernizr';

function getStartupFunction(startup : () => void) : () => void {
    return () => {
        const errorDetector = getWindowErrorDetector();
        errorDetector.addUnhandledErrorHandler(showModalOnUnhandledError);
        configureModernizr();

        if(!modernizr.passesTest('flexbox')) {
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
            if(!modernizr.passesTest('pointermq')) return false;
            if(!modernizr.passesTest('touchevents')) return false;
            return window.matchMedia('(pointer: coarse)').matches;
        }
    });
}

export default pageStarter;

//@flow
import 'element-remove';
import getWindowErrorDetector from './WindowErrorDetector';
import showModalOnUnhandledError from './showModalOnUnhandledError';

function getStartupFunction(startup : () => void) : () => void {
    return () => {
        const errorDetector = getWindowErrorDetector();
        errorDetector.addUnhandledErrorHandler(showModalOnUnhandledError);
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

export default pageStarter;

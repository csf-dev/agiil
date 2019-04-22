//@flow
import 'element-remove';

function pageStarter(startup : () => void) {
    let started = false;

    // Event handler for when the page loads
    document.addEventListener("DOMContentLoaded", () => {
        if(started) return;
        startup();
        started = true;
    });

    // In case the page is already loaded
    if(!started && document.readyState !== 'loading') {
        startup();
        started = true;
    }
}

export default pageStarter;

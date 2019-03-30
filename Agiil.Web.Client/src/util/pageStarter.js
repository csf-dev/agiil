//@flow

function pageStarter(startup : () => void) {
    document.addEventListener("DOMContentLoaded", startup);
}

export default pageStarter;

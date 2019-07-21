//@flow

let currentModal : ?UnhandledErrorModal = null;

export class UnhandledErrorModal {
    #doc : Document;
    #mask : HTMLDivElement;
    #dialog : HTMLDivElement;
    #heading : HTMLHeadingElement;
    #intro : HTMLParagraphElement;
    #toggleDetailButton : HTMLButtonElement;
    #closeButton : HTMLButtonElement;
    #errorDetail : HTMLPreElement;
    #showDetail : bool;
    #shown : bool;
    #destroyed : bool;

    show(error : Error) : void {
        if(this.#shown) throw new Error('Cannot show the same modal more than once.');
        if(this.#destroyed) throw new Error('Cannot reuse a modal that has already been destroyed.');

        console.log('UnhandledErrorModal handling an error');
        const $self = this;

        this.#mask = this.#doc.createElement('div');
        this.#mask.setAttribute('class', 'UnhandledPageError_Mask');

        this.#dialog = this.#doc.createElement('div');
        this.#dialog.setAttribute('class', 'UnhandledPageError_Dialog');
        this.#dialog.classList.add(this.#showDetail? 'open' : 'closed');
        this.#mask.appendChild(this.#dialog);

        this.#closeButton = this.#doc.createElement('button');
        this.#closeButton.setAttribute('class', 'UnhandledPageError_CloseButton');
        this.#closeButton.textContent = 'Close';
        this.#closeButton.addEventListener('click', () => $self.close());
        this.#dialog.appendChild(this.#closeButton);

        this.#heading = this.#doc.createElement('h1');
        this.#heading.textContent = 'Unexpected error';
        this.#dialog.appendChild(this.#heading);

        this.#intro = this.#doc.createElement('p');
        this.#intro.textContent = 'There has been an unexpected error on this page.';
        this.#dialog.appendChild(this.#intro);

        this.#toggleDetailButton = this.#doc.createElement('button');
        this.#toggleDetailButton.setAttribute('class', 'UnhandledPageError_ToggleButton');
        this.#toggleDetailButton.textContent = 'Show/hide detail';
        this.#toggleDetailButton.addEventListener('click', () => $self.toggleDetail());
        this.#dialog.appendChild(this.#toggleDetailButton);
        
        this.#errorDetail = this.#doc.createElement('pre');
        this.#errorDetail.textContent = error.stack;
        this.#dialog.appendChild(this.#errorDetail);

        this.#doc.getElementsByTagName('body')[0].appendChild(this.#mask);
        this.#shown = true;
    }

    close() {
        if(!this.#shown) throw new Error('Cannot close modal that is not shown.');
        this.#doc.getElementsByTagName('body')[0].removeChild(this.#mask);
        this.#destroyed = true;
        currentModal = null;
    }

    toggleDetail() {
        if(!this.#shown) throw new Error('Cannot toggle detail for a modal that is not shown.');
        this.#showDetail = !this.#showDetail;
        this.#dialog.classList.remove('open', 'closed');
        this.#dialog.classList.add(this.#showDetail? 'open' : 'closed');
    }

    constructor(win : any, showDetail : bool) {
        if(!win || !win.document) throw new Error('An HTML window object must be provided.');
        this.#doc = win.document;
        this.#showDetail = showDetail;
    }
}

export default function showModalOnUnhandledError(error : Error) : void {
    if(currentModal) return;
    currentModal = new UnhandledErrorModal(window, true);
    currentModal.show(error);
}
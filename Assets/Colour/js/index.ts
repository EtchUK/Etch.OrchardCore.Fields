const CSSClasses = {
    selected: 'is-selected',
};

(window as any).initializeColourEditor = (el: HTMLElement): void => {
    const $hiddenField: HTMLInputElement = el.querySelector(
        '.js-colour-hidden'
    ) as HTMLInputElement;

    let $selected: HTMLElement | null = el.querySelector('.is-selected');

    const customColourChange = function (this: HTMLInputElement) {
        if ($hiddenField) {
            $hiddenField.value = this.value;
        }

        setSelected(this);
    };

    const selectColour = function (this: HTMLButtonElement) {
        if ($hiddenField) {
            $hiddenField.value =
                this.getAttribute('data-colour')?.toString() || '';
        }

        setSelected(this);
    };

    const selectTransparent = function (this: HTMLButtonElement) {
        if ($hiddenField) {
            $hiddenField.value = 'transparent';
        }

        setSelected(this);
    };

    const setSelected = function ($el: HTMLElement) {
        if ($selected) {
            $selected.classList.remove(CSSClasses.selected);
        }

        $selected = $el;
        $selected.classList.add(CSSClasses.selected);

        $(document).trigger('contentpreview:render')
    };

    const $colourBtns = el.querySelectorAll('.js-colour-btn');

    for (var i = 0; i < $colourBtns.length; i++) {
        $colourBtns[i].addEventListener('click', selectColour);
    }

    el.querySelector('.js-transparent-btn')?.addEventListener(
        'click',
        selectTransparent
    );
    el.querySelector('.js-colour-input')?.addEventListener(
        'change',
        customColourChange
    );
};

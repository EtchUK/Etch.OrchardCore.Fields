import valuesEditor from './components/valuesEditor';

(window as any).initializeValuesEditor = (el: HTMLElement): void => {
    const $hiddenDataField = document.getElementById($(el).data('for'));

    if (!$hiddenDataField) {
        return;
    }

    valuesEditor($($hiddenDataField).data('init'), el);
};

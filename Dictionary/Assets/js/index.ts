import dictionaryEditor from './components/dictionaryEditor';

(window as any).initializeDictionaryEditor = (
    el: HTMLElement
): void => {
    const rawDataInputElement = document.getElementById($(el).data('for'));

    if (!rawDataInputElement) {
        return;
    }

    dictionaryEditor(
        $(rawDataInputElement).data('init')
    );
};
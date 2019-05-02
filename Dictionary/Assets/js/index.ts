import dictionaryEditor from './components/dictionaryEditor';

(window as any).initializeDictionaryEditor = (
    el: HTMLElement
): void => {
    const rawDataInputElement = document.getElementById($(el).data('for'));

    if (!rawDataInputElement) {
        return;
    }
    
    const maxEntriesInputElement = document.getElementById($(el).data('max')) as HTMLInputElement;
    const minEntriesInputElement = document.getElementById($(el).data('min')) as HTMLInputElement;

    let max: number | undefined = parseInt(maxEntriesInputElement.value, 10);
    let min: number | undefined = parseInt(minEntriesInputElement.value, 10);

    if (isNaN(max)) {
        max = undefined;
    }

    if (isNaN(min)) {
        min = undefined;
    }

    dictionaryEditor(
        $(rawDataInputElement).data('init'),
        el,
        max,
        min
    );
};
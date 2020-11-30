import responsiveMediaEditor from './components/responsiveMediaEditor';

declare global {
    interface Window {
        mediaApp: any;
    }
}

window.mediaApp = window.mediaApp || {};

(window as any).initializeResponsiveMediaEditor = (
    el: HTMLElement,
    modalBodyElement: HTMLElement,
    breakpoints: number[],
    isMultiple: boolean,
    allowMediaText: boolean
): void => {
    const rawDataInputElement = document.getElementById($(el).data('for'));

    if (!rawDataInputElement) {
        return;
    }

    breakpoints.sort((a, b) => {
        return a - b;
    });

    responsiveMediaEditor(
        el,
        $(rawDataInputElement).data('init'),
        modalBodyElement,
        breakpoints,
        isMultiple,
        allowMediaText
    );
};

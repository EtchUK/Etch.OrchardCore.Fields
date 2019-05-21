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
    breakpoints: number[]
): void => {
    const rawDataInputElement = document.getElementById($(el).data('for'));

    if (!rawDataInputElement) {
        return;
    }

    responsiveMediaEditor(
        $(rawDataInputElement).data('init'),
        modalBodyElement,
        breakpoints
    );
};

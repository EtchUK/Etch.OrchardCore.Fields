function isRelative(url: string): boolean {
    return url.indexOf('http') === -1;
}

export default function getUrlFromSelectedMedia(
    selectedMediaItem: any
): string | undefined {
    if (selectedMediaItem == null || selectedMediaItem.url == null) {
        return undefined;
    }

    if (isRelative(selectedMediaItem.url)) {
        return `${window.location.origin}${selectedMediaItem.url}`;
    }

    return selectedMediaItem.url;
}

import MediaItem from '../models/mediaItem';
import { sortNumbers } from './sortUtils';
import getUrlFromSelectedMediaItem from './getUrlFromSelectedMediaItem';

export default async function createMediaItem(
    breakpoints: number[],
    selectedMedia: any[]
): Promise<MediaItem> {
    const orderedBreakpoints = sortNumbers(breakpoints).reverse();

    let mediaItem = new MediaItem([]);

    return new Promise(resolve => {
        let processedCount = 0;

        const processNextImage = () => {
            const selectedMediaItem = selectedMedia[processedCount];
            const imageUrl = getUrlFromSelectedMediaItem(selectedMediaItem);
            if (imageUrl == null) {
                processNextImage();
                return;
            }

            var img = new Image();
            img.onload = function() {
                const imageWidth: number = (this as any).naturalWidth;
                let possibleBreakpoints: number[] = [];

                for (var i = 0; i < orderedBreakpoints.length; i++) {
                    if (
                        orderedBreakpoints[i] <= imageWidth &&
                        !mediaItem.hasSource(orderedBreakpoints[i])
                    ) {
                        possibleBreakpoints.push(orderedBreakpoints[i]);
                    }
                }

                if (possibleBreakpoints.length > 0) {
                    mediaItem.addSource(
                        Math.max(...possibleBreakpoints),
                        selectedMediaItem
                    );
                } else {
                    mediaItem.addSource(
                        0,
                        selectedMediaItem
                    );
                }

                processedCount++;

                if (processedCount === selectedMedia.length) {
                    resolve(mediaItem);
                    return;
                }

                processNextImage();
            };
            img.src = imageUrl;
        };

        processNextImage();
    });
}

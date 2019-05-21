import MediaItem from '../models/mediaItem';
import { sortNumbers } from './sortUtils';

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
            const imageUrl = `${window.location.origin}${
                selectedMediaItem.url
            }`;

            var img = new Image();
            img.onload = function() {
                const imageWidth: number = (this as any).naturalWidth;

                for (var i = 0; i < orderedBreakpoints.length; i++) {
                    if (
                        orderedBreakpoints[i] <= imageWidth &&
                        !mediaItem.hasSource(orderedBreakpoints[i])
                    ) {
                        mediaItem.addSource(
                            orderedBreakpoints[i],
                            selectedMediaItem
                        );
                        break;
                    }
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

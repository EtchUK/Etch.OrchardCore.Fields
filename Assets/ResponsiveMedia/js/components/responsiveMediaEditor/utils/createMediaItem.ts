import MediaItem from '../models/mediaItem';
import MediaSource from '../models/mediaSource';

export default async function createMediaItem(
    breakpoints: number[],
    selectedMedia: any
): Promise<MediaItem> {
    const imageUrl = `${window.location.origin}${selectedMedia.url}`;
    const orderedBreakpoints = breakpoints.sort().reverse();

    return new Promise(resolve => {
        var img = new Image();
        img.onload = function() {
            const imageWidth: number = (this as any).naturalWidth;

            for (var i = 0; i < orderedBreakpoints.length; i++) {
                if (orderedBreakpoints[i] === imageWidth) {
                    resolve(
                        new MediaItem([
                            new MediaSource(
                                orderedBreakpoints[i],
                                selectedMedia.name,
                                selectedMedia.mediaPath,
                                selectedMedia.url
                            ),
                        ])
                    );
                }
            }
        };
        img.src = imageUrl;
    });
}

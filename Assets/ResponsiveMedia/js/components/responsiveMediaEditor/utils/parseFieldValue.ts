import MediaItem from '../models/mediaItem';
import MediaSource from '../models/mediaSource';

export default function parseFieldValue(initialData: any): MediaItem[] {
    if (!initialData) {
        return [];
    }

    return initialData.map(
        (i: any) =>
            new MediaItem(
                i.mediaText,
                i.sources.map(
                    (x: any) =>
                        new MediaSource(x.breakpoint, x.name, x.path, x.url)
                )
            )
    );
}

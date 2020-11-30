import MediaSource from './mediaSource';
import { sortNumbers } from '../utils/sortUtils';

export interface IMediaItem {
    mediaText: string;
    sources: MediaSource[];

    addSource(breakpoint: number, media: any): void;
    getSourceAt(breakpoint: number): MediaSource | null;
}

export default class MediaItem {
    mediaText: string;
    sources: MediaSource[];

    constructor(mediaText: string, source: MediaSource[] | undefined) {
        this.mediaText = mediaText;
        this.sources = source || new Array<MediaSource>();
    }

    /**
     * Adds a new image source for a breakpoint.
     */
    addSource(breakpoint: number, media: any): void {
        let existingSource: MediaSource | null = null;

        for (let i: number = 0; i < this.sources.length; i++) {
            if (this.sources[i].breakpoint === breakpoint) {
                existingSource = this.sources[i];
                break;
            }
        }

        if (existingSource !== null) {
            existingSource.name = media.name;
            existingSource.path = media.mediaPath;
            existingSource.url = media.url;
            return;
        }

        this.sources.push(
            new MediaSource(breakpoint, media.name, media.mediaPath, media.url)
        );
    }

    /**
     * Returns list of breakpoints associated to sources.
     */
    getBreakpoints(): number[] {
        return this.sources.map((x) => x.breakpoint);
    }

    /**
     * Gets the largest breakpoint associated to sources.
     */
    getLargestBreakpoint(): number {
        let largestBreakpoint: number = 0;

        for (let i: number = 0; i < this.sources.length; i++) {
            if (this.sources[i].breakpoint > largestBreakpoint) {
                largestBreakpoint = this.sources[i].breakpoint;
            }
        }

        return largestBreakpoint;
    }

    /**
     * Returns the source associated to the provided breakpoint. If
     * one isn't found then `null` is returned.
     */
    getSourceAt(breakpoint: number): MediaSource | null {
        if (!this.sources || !this.sources.length) {
            return null;
        }

        let matchingSource: MediaSource | undefined = this.sources.find(
            (value) => {
                return value.breakpoint === breakpoint;
            }
        );

        return matchingSource || null;
    }

    /**
     * Returns the source associated to the provided breakpoint. If
     * one isn't defined, the source associated to the next largest
     * breakpoint will be returned. If there isn't a source defined
     * for a larger breakpoint, then `null` is returned.
     */
    getSourceOrAlternative(breakpoint: number): MediaSource | null {
        const matchingSource = this.getSourceAt(breakpoint);

        if (matchingSource) {
            return matchingSource;
        }

        const breakpoints = sortNumbers(this.getBreakpoints());

        for (var i = 0; i < breakpoints.length; i++) {
            if (breakpoints[i] < breakpoint) {
                continue;
            }

            return this.getSourceAt(breakpoints[i]);
        }

        return null;
    }

    /**
     * Returns URL for source associated to provided breakpoint. If no source
     * matches the breakpoint then the resized URL for the next largest breakpoint
     * will be returned. When there isn't a larger breakpoint, an empty string
     * is returned.
     */
    getUrlAt(breakpoint: number): string {
        const matchingSource = this.getSourceAt(breakpoint);

        if (!matchingSource) {
            const alternateSource = this.getSourceOrAlternative(breakpoint);

            return alternateSource
                ? `${alternateSource.url}?width=${breakpoint}`
                : '';
        }

        return matchingSource.url;
    }

    /**
     * Returns whether there is a source for the provided breakpoint.
     */
    hasSource(breakpoint: number): boolean {
        return this.getSourceAt(breakpoint) !== null;
    }

    removeBreakpoint(breakpoint: number): boolean {
        let matchingSource = this.getSourceAt(breakpoint);

        if (matchingSource) {
            this.sources.splice(this.sources.indexOf(matchingSource), 1);
        }

        return this.sources.length === 0;
    }
}

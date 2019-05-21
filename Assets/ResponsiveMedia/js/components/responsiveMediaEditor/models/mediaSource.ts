export default class MediaSource {
    breakpoint: number;
    name: string;
    path: string;
    url: string;

    constructor(breakpoint: number, name: string, path: string, url: string) {
        this.breakpoint = breakpoint;
        this.name = name;
        this.path = path;
        this.url = url;
    }
}

import 'bootstrap';
import $ from 'jquery';
import Vue from 'vue';
import MediaSource from './models/mediaSource';
import MediaItem from './models/mediaItem';
import ResponsiveMediaItem from './components/responsiveMediaItem';
import createMediaItem from './utils/createMediaItem';
import parseFieldValue from './utils/parseFieldValue';

const selectors = {
    mediaApp: '#mediaApp',
    mediaFieldSelectButton: '.mediaFieldSelectButton',
    modalBody: '.modal-body',
};

interface IMediaItemEventArgs {
    breakpoint: number;
    media: MediaItem;
}

export default (
    el: HTMLElement,
    initialData: any,
    modalBodyElement: HTMLElement,
    breakpoints: number[]
) => {
    return new Vue({
        el,

        data: {
            breakpoints,
            mediaItems: [] as MediaItem[],
        },

        components: {
            ResponsiveMediaItem,
        },

        computed: {
            hasMedia(): boolean {
                return this.mediaItems.length > 0;
            },
            value(): string {
                return JSON.stringify(
                    this.mediaItems.map((x: MediaItem) => {
                        return {
                            sources: x.sources.map((source: MediaSource) => {
                                return {
                                    breakpoint: source.breakpoint,
                                    path: source.path,
                                };
                            }),
                        };
                    })
                );
            },
        },

        mounted: function() {
            this.mediaItems = parseFieldValue(initialData);
        },

        methods: {
            add: function(): void {
                const self = this;

                $(selectors.mediaApp)
                    .detach()
                    .appendTo($(modalBodyElement).find(selectors.modalBody));

                $(selectors.mediaApp).show();

                const modal = $(modalBodyElement).modal();

                $(modalBodyElement)
                    .find(selectors.mediaFieldSelectButton)
                    .off('click')
                    .on('click', async function() {
                        if (window.mediaApp.selectedMedias.length) {
                            const selectedMedias =
                                window.mediaApp.selectedMedias;

                            for (var i = 0; i < selectedMedias.length; i++) {
                                self.mediaItems.push(
                                    await createMediaItem(
                                        self.breakpoints,
                                        selectedMedias[i]
                                    )
                                );
                            }
                        }

                        window.mediaApp.selectedMedias = [];

                        modal.modal('hide');
                        return true;
                    });
            },

            remove: function(args: IMediaItemEventArgs): void {
                this.mediaItems.splice(this.mediaItems.indexOf(args.media), 1);
            },

            update: function(args: IMediaItemEventArgs): void {
                $(selectors.mediaApp)
                    .detach()
                    .appendTo($(modalBodyElement).find(selectors.modalBody));

                $(selectors.mediaApp).show();

                const modal = $(modalBodyElement).modal();

                $(modalBodyElement)
                    .find(selectors.mediaFieldSelectButton)
                    .off('click')
                    .on('click', async function() {
                        if (window.mediaApp.selectedMedias.length) {
                            args.media.addSource(
                                args.breakpoint,
                                window.mediaApp.selectedMedias[0]
                            );
                        }

                        window.mediaApp.selectedMedias = [];

                        modal.modal('hide');
                        return true;
                    });
            },
        },
    });
};
import 'bootstrap';
import $ from 'jquery';
import Vue from 'vue';
import MediaSource from './models/mediaSource';
import { IMediaItem } from './models/mediaItem';
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
    media: IMediaItem;
}

export default (
    el: HTMLElement,
    initialData: any,
    modalBodyElement: HTMLElement,
    breakpoints: number[],
    isMultiple: boolean,
    allowMediaText: boolean
) => {
    return new Vue({
        el,

        data: {
            allowMediaText,
            backupMediaText: '',
            breakpoints,
            isMultiple,
            mediaItems: [] as IMediaItem[],
            selectedMedia: {
                mediaText: '',
            },
        },

        components: {
            ResponsiveMediaItem,
        },

        computed: {
            canAdd(): boolean {
                return this.isMultiple || this.mediaItems.length === 0;
            },
            hasMedia(): boolean {
                return this.mediaItems.length > 0;
            },
            value(): string {
                return JSON.stringify(
                    this.mediaItems.map((x: IMediaItem) => {
                        return {
                            mediaText: x.mediaText,
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

        mounted: function () {
            this.mediaItems = parseFieldValue(initialData);
        },

        methods: {
            add: function (): void {
                const self = this;

                $(selectors.mediaApp)
                    .detach()
                    .appendTo($(modalBodyElement).find(selectors.modalBody));

                $(selectors.mediaApp).show();

                const modal = $(modalBodyElement).modal();

                $(modalBodyElement)
                    .find(selectors.mediaFieldSelectButton)
                    .off('click')
                    .on('click', async function () {
                        if (window.mediaApp.selectedMedias.length) {
                            self.mediaItems.push(
                                await createMediaItem(
                                    self.breakpoints,
                                    window.mediaApp.selectedMedias
                                )
                            );
                        }

                        window.mediaApp.selectedMedias = [];

                        modal.modal('hide');
                        return true;
                    });
            },

            cancelMediaTextModal: function (): void {
                $(this.$refs.mediaTextModal).modal('hide');
                this.selectedMedia.mediaText = this.backupMediaText;
            },

            remove: function (args: IMediaItemEventArgs): void {
                this.mediaItems.splice(this.mediaItems.indexOf(args.media), 1);
            },

            showMediaText: function (args: IMediaItemEventArgs): void {
                this.selectedMedia = args.media;
                $(this.$refs.mediaTextModal).modal();
                this.backupMediaText = this.selectedMedia.mediaText;
            },

            update: function (args: IMediaItemEventArgs): void {
                $(selectors.mediaApp)
                    .detach()
                    .appendTo($(modalBodyElement).find(selectors.modalBody));

                $(selectors.mediaApp).show();

                const modal = $(modalBodyElement).modal();

                $(modalBodyElement)
                    .find(selectors.mediaFieldSelectButton)
                    .off('click')
                    .on('click', async function () {
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

            updatePreview: function () {
                this.$nextTick(() => {
                    $(document).trigger('contentpreview:render');
                });
            },
        },

        watch: {
            mediaItems: function () {
                this.updatePreview();
            },
        },
    });
};

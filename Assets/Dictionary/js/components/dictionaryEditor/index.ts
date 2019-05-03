import Vue from 'vue';
import DictionaryItem from './models/dictionaryItem';

export default (
    initialData: any,
    element: HTMLElement,
    max?: number,
    min?: number
) => {
    const parsedData: DictionaryItem[] = initialData ?
        initialData.map(
            (i: any) => ({
                name: i.Name,
                value: i.Value
            })
        ) :
        [];


    return new Vue({
        el: element,

        data: {
            dictionaryItems: [] as DictionaryItem[],
            maxEntries: max,
            minEntries: min
        },

        computed: {
            hasEntries(): boolean {
                return this.dictionaryItems.length > 0;
            },
            hasMinEntries(): boolean {
                return this.minEntries == null || this.minEntries < 1 || this.dictionaryItems.length >= this.minEntries;
            },
            isMaxEntries(): boolean {
                return this.maxEntries != null && this.maxEntries > 0 && this.dictionaryItems.length >= this.maxEntries;
            },
            value(): string {
                return JSON.stringify(this.dictionaryItems);
            }
        },

        mounted: function () {
            this.dictionaryItems = parsedData;
        },

        methods: {
            add: function () {
                if (this.maxEntries && this.dictionaryItems.length >= this.maxEntries) {
                    return;
                }
                this.dictionaryItems.push({ name: '', value: '' });
            },
            remove: function (index: number) {
                this.dictionaryItems.splice(index, 1);
            }
        }
    });
};
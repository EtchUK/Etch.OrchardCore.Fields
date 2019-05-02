import Vue from 'vue';
import DictionaryItem from './models/dictionaryItem';

export default (
    initialData: any,
    element: HTMLElement
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
            dictionaryItems: [] as DictionaryItem[]
        },

        computed: {
            hasEntries(): boolean {
                return this.dictionaryItems.length > 0;
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
                this.dictionaryItems.push({ name: '', value: '' });
            },
            remove: function (index: number) {
                this.dictionaryItems.splice(index, 1);
            }
        }
    });
};
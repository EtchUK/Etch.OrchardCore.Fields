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

    const focusField = (ref: Vue | Element | Vue[] | Element[], index: number) => {
        const elements = ref as Element[];
        if (index >= elements.length) {
            return;
        }
        const input = elements[index] as HTMLInputElement;
        if (input == null) {
            return;
        }
        input.focus();
        input.setSelectionRange(input.value.length, input.value.length);
    };

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
                this.$nextTick(() => {
                    const index = this.dictionaryItems.length - 1;
                    focusField(this.$refs.name, index);
                });
            },
            handleBackspace: function (ref: string, index: number, event: KeyboardEvent) {
                const value = (this.dictionaryItems[index] as any)[ref] as string;
                if (value.length > 0) {
                    return;
                }
                event.preventDefault();
                if (ref === 'name') {
                    if(this.dictionaryItems[index].value.length === 0){
                        this.remove(index);
                    }
                    focusField(this.$refs.value, index - 1);
                } else {
                    focusField(this.$refs.name, index);
                }
            },
            handleDown: function (ref: string, index: number) {
                focusField(this.$refs[ref], index + 1);
            },
            handleUp: function (ref: string, index: number) {
                focusField(this.$refs[ref], index - 1);
            },
            nextField: function (ref: string, index: number) {
                let selectIndex = ref === 'value' ? index + 1 : index;
                const selectRef = ref === 'value' ? 'name' : 'value';
                if (ref === 'value' && selectIndex >= this.dictionaryItems.length) {
                    this.add();
                    return;
                }
                focusField(this.$refs[selectRef], selectIndex);
            },
            remove: function (index: number) {
                this.dictionaryItems.splice(index, 1);
            },
            updatePreview: function () {
                this.$nextTick(() => {
                    $(document).trigger('contentpreview:render');
                });
            }
        },

        watch: {
            dictionaryItems: function () {
                this.updatePreview();
            }
        }
    });
};
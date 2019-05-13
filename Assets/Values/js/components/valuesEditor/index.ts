import Vue from 'vue';

export default (initialData: string[], element: HTMLElement) => {
    return new Vue({
        el: element,

        data: {
            items: [] as string[],
            newValue: '',
        },

        computed: {
            hasValues(): boolean {
                return this.items.length > 0;
            },
            value(): string {
                return JSON.stringify(this.items);
            },
        },

        mounted: function() {
            this.items = initialData;
        },

        methods: {
            add: function() {
                if (!this.newValue) {
                    return;
                }

                this.items.push(this.newValue);
                this.newValue = '';
            },
            remove: function(index: number) {
                this.items.splice(index, 1);
            },
        },
    });
};

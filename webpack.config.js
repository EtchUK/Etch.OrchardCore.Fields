const path = require('path');

module.exports = {
    entry: {
        dictionary: './Assets/Dictionary/js/index.ts',
        responsiveMedia: './Assets/ResponsiveMedia/js/index.ts',
        values: './Assets/Values/js/index.ts',
    },
    mode: 'development',
    module: {
        rules: [
            {
                test: /\.tsx?$/,
                use: 'ts-loader',
                exclude: /node_modules/,
            },
        ],
    },
    resolve: {
        extensions: ['.tsx', '.ts', '.js'],
        alias: {
            vue$: 'vue/dist/vue.esm.js',
        },
    },
    externals: {
        bootstrap: 'bootstrap',
        jquery: 'jQuery',
        vue: 'Vue',
    },
    output: {
        filename: '[name]/admin.js',
        path: path.resolve(__dirname, './wwwroot/Scripts/'),
    },
};

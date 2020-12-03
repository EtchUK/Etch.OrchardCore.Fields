const CopyPlugin = require('copy-webpack-plugin');
const path = require('path');

module.exports = {
    entry: {
        colour: './Assets/Colour/js/index.ts',
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
    plugins: [
        new CopyPlugin([
            {
                from: './node_modules/ace-builds/src-noconflict/ace.js',
                to: path.resolve(
                    __dirname,
                    './wwwroot/Scripts/code/ace/ace.js'
                ),
            },
            {
                from:
                    './node_modules/ace-builds/src-noconflict/mode-javascript.js',
                to: path.resolve(
                    __dirname,
                    './wwwroot/Scripts/code/ace/mode-javascript.js'
                ),
            },
            {
                from:
                    './node_modules/ace-builds/src-noconflict/theme-crimson_editor.js',
                to: path.resolve(
                    __dirname,
                    './wwwroot/Scripts/code/ace/theme-crimson_editor.js'
                ),
            },
            {
                from:
                    './node_modules/ace-builds/src-noconflict/worker-javascript.js',
                to: path.resolve(
                    __dirname,
                    './wwwroot/Scripts/code/ace/worker-javascript.js'
                ),
            },
        ]),
    ],
};

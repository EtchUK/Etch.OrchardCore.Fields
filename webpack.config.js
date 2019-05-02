const path = require('path');

module.exports = {
    entry: {
        dictionary: './ResponsiveMedia/Assets/js/index.ts',
        reponsiveMedia: './ResponsiveMedia/Assets/js/index.ts'
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

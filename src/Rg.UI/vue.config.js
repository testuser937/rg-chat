const {defineConfig} = require('@vue/cli-service')
const path = require("path");
module.exports = defineConfig({
    lintOnSave: false,
    runtimeCompiler: true,
    transpileDependencies: [
        'vuetify'
    ],
    configureWebpack: config => {
        config.resolve.modules = [path.resolve(__dirname, 'node_modules')]
    },
    productionSourceMap: false,
})

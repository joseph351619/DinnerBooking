const path = require("path");

module.exports = {
    chainWebpack: config => {
        const apiClient = process.env.VUE_APP_API_CLIENT; // mock or server
        config
            .entry("app")
            .clear()
            .add("./client/main.js")
            .end();
        config.resolve.alias
            .set('@api-client', path.join(__dirname, 'src/api/${apiClient}'))
    }
};
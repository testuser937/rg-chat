export class SiteSettings {
    static baseUrl(): string {
        return process.env.VUE_APP_ApiBaseUrl;
    }
}
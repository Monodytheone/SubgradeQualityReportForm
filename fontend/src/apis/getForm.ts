import instanceWithAuthorization from "./instanceWithAuthorization";

export default function (formId: string) {
    return instanceWithAuthorization({
        baseURL: process.env.VUE_APP_FORMSERVICE_URL,
        url: `api/Form/GetForm/${formId}`,
        method: 'GET',
    })
}
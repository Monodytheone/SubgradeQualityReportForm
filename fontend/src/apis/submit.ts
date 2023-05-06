import SubgradeType from "@/types/SubgradeType";
import commonInstance from "./commonInstance";
import FormDetail from "@/types/FormDetail";

export default function (formDetail: FormDetail) {
    let requestBody = formDetail;
    requestBody.SubgradeType = formDetail.SubgradeType === SubgradeType.Earthwork ? SubgradeType.Earthwork : SubgradeType.Stone
    return commonInstance({
        baseURL: process.env.VUE_APP_FORMSERVICE_URL,
        url: 'api/Form/Submit',
        method: 'POST',
        data: formDetail,
    })
}
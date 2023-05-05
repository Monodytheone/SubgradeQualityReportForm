import SubgradeType from "./SubgradeType";
import DateInfo from "./DateInfo";
import InspectionDetail from "./InspectionDetail";

export default interface FormDetail {
    ExpresswayName: string;
    ContractorCompany: string;
    SupervisionCompany: string;
    ContractNumber: string;
    SerialNumber: string;
    SubgradeType: SubgradeType;
    ProjectName: string;
    StakeNumberAndLocation: string;
    StartDate?: DateInfo;
    EndDate?: DateInfo;
    InspectionDate?: DateInfo;
    Items: InspectionDetail[];
    IsQualified?: boolean;
    UnqualifiedItems: string;
    SupervisorName: string;
    SigningDate?: DateInfo;
}
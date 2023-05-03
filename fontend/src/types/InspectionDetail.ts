export default interface InspectionDetail {
    /** 规定值及允许偏差 */
    SpecifiedValueAndAllowableDeviation: string;

    /** 检查结果 */
    InspectionResult: string;

    /** 检验结果附表代码 */
    Code: string;
    
    /** 备注（可空） */
    Note?: string;
}
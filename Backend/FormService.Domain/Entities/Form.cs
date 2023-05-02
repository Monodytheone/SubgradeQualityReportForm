using FormService.Domain.Entities.Enums;
using FormService.Domain.Entities.ValueObjects;
using System.Net.Http.Headers;

namespace FormService.Domain.Entities;

public class Form
{
    public Guid Id { get; init; }

    public DateTime SubmitTime { get; init; }

    public string ExpresswayName { get; init; }

    /// <summary>
    /// 承包单位
    /// </summary>
    public string ContractorCompany { get; init; }

    /// <summary>
    /// 监理单位
    /// </summary>
    public string SupervisionCompany { get; init; }

    /// <summary>
    /// 合同号
    /// </summary>
    public string ContractNumber { get; init; }

    /// <summary>
    /// 编号
    /// </summary>
    public string SerialNumber { get; init; }

    /// <summary>
    /// 土方路基/石方路基
    /// </summary>
    public SubgradeType SubgradeType { get; init; }

    /// <summary>
    /// 工程名称
    /// </summary>
    public string ProjectName { get; init; }

    /// <summary>
    /// 桩号及部位
    /// </summary>
    public string StakeNumberAndLocation { get; init; }

    /// <summary>
    /// 施工日期
    /// </summary>
    public ConstructionDate ConstructionDate { get; init; }

    /// <summary>
    /// 检验日期
    /// </summary>
    public DateOnly InspectionDate { get; init; }





    // 接下来是1Δ部分，因为条目数量已知，全部做成值对象，存进Form表中，无非就是字段多了些而已；做成外键的话不仅耗费性能且数据库中的数据不直观

    /// <summary>
    /// 1Δ 压实度或沉降差 零填及路堑 0~0.80m
    /// <para>第一大行</para>
    /// </summary>
    public InspectionDetail ZeroFillingAndCutting_0_0dot80m_ { get; init; }

    /// <summary>
    /// 轻、中及重载荷等级 0~0.80m
    /// <para>第1小行</para>
    /// </summary>
    public InspectionDetail LightModerateAndHeavy_0_0dot80m_ { get; init; }

    /// <summary>
    /// 特重、极重载荷等级 0~1.20m
    /// <para>第2小行</para>
    /// </summary>
    public InspectionDetail ExtraAndExtremely_0_1dot20m_ { get; init; }

    /// <summary>
    /// 轻、中及重载荷等级 0.80~1.50m
    /// <para>第3小行</para>
    /// </summary>
    public InspectionDetail LightModerateAndHeavy_0dot80_1dot50m_ { get; init; }

    /// <summary>
    /// 特重、极重载荷等级 1.20~1.90m
    /// <para>第4小行</para>
    /// </summary>
    public InspectionDetail ExtraAndExtremely_1dot20_1dot90m_ { get; init; }

    /// <summary>
    /// 轻、中及重载荷等级 >1.50m
    /// <para>第5小行</para>
    /// </summary>
    public InspectionDetail LightModerateAndHeavy_GreaterThan_1dot50m_ { get; init; }

    /// <summary>
    /// 特重、极重载荷登记 >1.90m
    /// <para>第6小行</para>
    /// </summary>
    public InspectionDetail ExtraAndExtremely_GreaterThan_1dot90m_ { get; init; }




    // 2Δ 弯沉可能做好几个，是一个一对多关系，因此单独存进一个表
    public List<Deflection> Deflections { get; init; }


    /// <summary>
    /// 监理意见（值对象）
    /// </summary>
    public SupervisorOpinion SupervisorOpinion { get; init; }



    private Form() { }




    public class Builder
    {
        private string _expresswayName;
        private string _contractorCompany;
        private string _supervisionCompany;
        private string _contractNumber;
        private string _serialNumber;
        private SubgradeType _subgradeType;
        private string _projectName;
        private string _stakeNumberAndLocation;
        private DateOnly _startDate;
        private DateOnly _endDate;
        private DateOnly _inspectionDate;

        // 1Δ：
        private InspectionDetail _row0;
        private InspectionDetail _row1;
        private InspectionDetail _row2;
        private InspectionDetail _row3;
        private InspectionDetail _row4;
        private InspectionDetail _row5;
        private InspectionDetail _row6;

        private List<Deflection> _deflections;

        private SupervisorOpinion _supervisorOpinion;


        public Builder ExpresswayName(string value)
        {
            _expresswayName = value;
            return this;
        }
        public Builder ContractorCompany(string value)
        {
            _contractorCompany = value;
            return this;
        }
        public Builder SupervisionCompany(string value)
        {
            _supervisionCompany = value;
            return this;
        }
        public Builder ContractNumber(string value)
        {
            _contractNumber = value;
            return this;
        }
        public Builder SerialNumber(string value)
        {
            _serialNumber = value;
            return this;
        }
        public Builder SubgradeType(SubgradeType value)
        {
            _subgradeType = value;
            return this;
        }
        public Builder ProjectName(string value)
        {
            _projectName = value;
            return this;
        }
        public Builder StakeNumberAndLocation(string value)
        {
            _stakeNumberAndLocation = value;
            return this;
        }
        public Builder StartDate(int year, int month, int day)
        {
            _startDate = new DateOnly(year, month, day);
            return this;
        }
        public Builder EndDate(int year, int month, int day)
        {
            _endDate = new DateOnly(year, month, day);
            return this;
        }
        public Builder InspectionDate(int year, int month, int day)
        {
            _inspectionDate = new DateOnly(year, month, day);
            return this;
        }

        public Builder Row0__ZeroFillingAndCutting_0_0dot80m(InspectionDetail detail)
        {
           _row0 = detail;
            return this;
        }
        public Builder Row0__ZeroFillingAndCutting_0_0dot80m(string specifiedValueAndAllowableDeviation, string inspectionResult, string code, string? note)
        {
            _row0 = new InspectionDetail(specifiedValueAndAllowableDeviation, inspectionResult, code, note);
            return this;
        }
        public Builder Row1__LightModerateAndHeavy_0_0dot80m(InspectionDetail detail)
        {
            _row1 = detail;
            return this;
        }
        public Builder Row1__LightModerateAndHeavy_0_0dot80m(string specifiedValueAndAllowableDeviation, string inspectionResult, string code, string? note)
        {
            _row1 = new InspectionDetail(specifiedValueAndAllowableDeviation, inspectionResult, code, note);
            return this;
        }
        public Builder Row2__LightModerateAndHeavy_0_0dot80m(InspectionDetail detail)
        {
            _row2 = detail;
            return this;
        }
        public Builder Row2__LightModerateAndHeavy_0_0dot80m(string specifiedValueAndAllowableDeviation, string inspectionResult, string code, string? note)
        {
            _row2 = new InspectionDetail(specifiedValueAndAllowableDeviation, inspectionResult, code, note);
            return this;
        }
        public Builder Row3__LightModerateAndHeavy_0_0dot80m(InspectionDetail detail)
        {
            _row3 = detail;
            return this;
        }
        public Builder Row3__LightModerateAndHeavy_0_0dot80m(string specifiedValueAndAllowableDeviation, string inspectionResult, string code, string? note)
        {
            _row3 = new InspectionDetail(specifiedValueAndAllowableDeviation, inspectionResult, code, note);
            return this;
        }
        public Builder Row4__LightModerateAndHeavy_0_0dot80m(InspectionDetail detail)
        {
            _row4 = detail;
            return this;
        }
        public Builder Row4__LightModerateAndHeavy_0_0dot80m(string specifiedValueAndAllowableDeviation, string inspectionResult, string code, string? note)
        {
            _row4 = new InspectionDetail(specifiedValueAndAllowableDeviation, inspectionResult, code, note);
            return this;
        }
        public Builder Row5__LightModerateAndHeavy_0_0dot80m(InspectionDetail detail)
        {
            _row5 = detail;
            return this;
        }
        public Builder Row5__LightModerateAndHeavy_0_0dot80m(string specifiedValueAndAllowableDeviation, string inspectionResult, string code, string? note)
        {
            _row5 = new InspectionDetail(specifiedValueAndAllowableDeviation, inspectionResult, code, note);
            return this;
        }
        public Builder Row6__LightModerateAndHeavy_0_0dot80m(InspectionDetail detail)
        {
            _row6 = detail;
            return this;
        }
        public Builder Row6__LightModerateAndHeavy_0_0dot80m(string specifiedValueAndAllowableDeviation, string inspectionResult, string code, string? note)
        {
            _row6 = new InspectionDetail(specifiedValueAndAllowableDeviation, inspectionResult, code, note);
            return this;
        }
        

        public Builder Deflections(List<Deflection> deflections)
        {
            _deflections = deflections;
            return this;
        }


        public Builder Qualify(string supervisorName)
        {
            _supervisorOpinion = new(true, null, supervisorName);
            return this;
        }

        public Builder Unqualify(string supervisorName, string unqualifiedItems)
        {
            _supervisorOpinion = new(false, unqualifiedItems, supervisorName);
            return this;
        }


        public Form Build()
        {
            if(_expresswayName == null)
            {
                throw new ArgumentOutOfRangeException(nameof(_expresswayName));
            }
            if (_contractorCompany == null)
            {
                throw new ArgumentOutOfRangeException(nameof(_contractorCompany));
            }
            if (_supervisionCompany == null)
            {
                throw new ArgumentOutOfRangeException(nameof(_supervisionCompany));
            }
            if (_contractNumber == null)
            {
                throw new ArgumentOutOfRangeException(nameof(_contractNumber));
            }
            if (_serialNumber == null)
            {
                throw new ArgumentOutOfRangeException(nameof(_serialNumber));
            }
            if (_subgradeType == Enums.SubgradeType.Unset)
            {
                throw new ArgumentOutOfRangeException(nameof(_subgradeType));
            }
            if (_projectName == null)
            {
                throw new ArgumentOutOfRangeException(nameof(_projectName));
            }
            if (_stakeNumberAndLocation == null)
            {
                throw new ArgumentOutOfRangeException(nameof(_stakeNumberAndLocation));
            }
            if (_startDate == default)
            {
                throw new ArgumentOutOfRangeException(nameof(_startDate));
            }
            if (_endDate == default)
            {
                throw new ArgumentOutOfRangeException(nameof(_endDate));
            }
            if (_inspectionDate == default)
            {
                throw new ArgumentOutOfRangeException(nameof(_inspectionDate));
            }
            if (_row0 == null)
            {
                throw new ArgumentOutOfRangeException(nameof(_inspectionDate));
            }
            if (_row1 == null)
            {
                throw new ArgumentOutOfRangeException(nameof(_inspectionDate));
            }
            if (_row2 == null)
            {
                throw new ArgumentOutOfRangeException(nameof(_inspectionDate));
            }
            if (_row3 == null)
            {
                throw new ArgumentOutOfRangeException(nameof(_inspectionDate));
            }
            if (_row4 == null)
            {
                throw new ArgumentOutOfRangeException(nameof(_inspectionDate));
            }
            if (_row5 == null)
            {
                throw new ArgumentOutOfRangeException(nameof(_inspectionDate));
            }
            if (_row6 == null)
            {
                throw new ArgumentOutOfRangeException(nameof(_inspectionDate));
            }
            if (_deflections == null)
            {
                throw new ArgumentOutOfRangeException(nameof(_deflections));
            }
            if (_supervisorOpinion == null)
            {
                throw new ArgumentOutOfRangeException(nameof(_supervisorOpinion));
            }

            Form form = new()
            {
                SubmitTime = DateTime.Now,
                ExpresswayName = _expresswayName,
                ContractorCompany = _contractorCompany,
                SupervisionCompany = _supervisionCompany,
                ContractNumber = _contractNumber,
                SerialNumber = _serialNumber,
                SubgradeType = _subgradeType,
                ProjectName = _projectName,
                StakeNumberAndLocation = _stakeNumberAndLocation,
                ConstructionDate = new(_startDate, _endDate),
                InspectionDate = _inspectionDate,
                ZeroFillingAndCutting_0_0dot80m_ = _row0,
                LightModerateAndHeavy_0_0dot80m_ = _row1,
                ExtraAndExtremely_0_1dot20m_ = _row2,
                LightModerateAndHeavy_0dot80_1dot50m_ = _row3,
                ExtraAndExtremely_1dot20_1dot90m_ = _row4,
                LightModerateAndHeavy_GreaterThan_1dot50m_ = _row5,
                ExtraAndExtremely_GreaterThan_1dot90m_ = _row6,
                Deflections = _deflections,
                SupervisorOpinion = _supervisorOpinion,
            };
            return form;
        }
    }
}

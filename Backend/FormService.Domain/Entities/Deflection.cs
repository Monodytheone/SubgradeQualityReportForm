using FormService.Domain.Entities.ValueObjects;

namespace FormService.Domain.Entities;

/// <summary>
/// 弯沉
/// </summary>
public class Deflection
{
    public Guid Id { get; init; }

    /// <summary>
    /// 所属表单
    /// </summary>
    public Form Form { get; init; }

    /// <summary>
    /// 是表单中的第几个弯沉
    /// </summary>
    public int SequenceInForm { get; init; }

    public InspectionDetail InspectionDetail { get; init; }

    private Deflection() { }

    public Deflection(Form form, int sequenceInForm, 
        string specifiedValueAndAllowableDeviation, string inspectionResult, string code, string note)
    {
        Form = form;
        SequenceInForm = sequenceInForm;
        InspectionDetail = new(specifiedValueAndAllowableDeviation, inspectionResult, code, note);
    }
}

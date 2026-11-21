using Auto_Repair_Managment.Enums;

namespace Auto_Repair_Managment.Entity;

public sealed class Mechanic : EntityBase
{
    private const int MaxExperienceYears = 60;

    public string FullName { get; private set; }

    public QualificationLevel Qualification { get; private set; }

    public MechanicSpecialization Specialization { get; private set; }

    public int ExperienceYears { get; private set; }

    private Mechanic(
        string fullName,
        QualificationLevel qualification,
        MechanicSpecialization specialization,
        int experienceYears)
    {
        FullName = fullName;
        Qualification = qualification;
        Specialization = specialization;
        ExperienceYears = experienceYears;
    }

    public static Mechanic Create(
        string fullName,
        QualificationLevel qualification,
        MechanicSpecialization specialization,
        int experienceYears)
    {
        return new Mechanic(
            Guard.RequireText(fullName, "ФИО механика"),
            Guard.RequireDefined(qualification, "Квалификация"),
            specialization,
            ValidateExperience(experienceYears));
    }

    public void Update(
        string fullName,
        QualificationLevel qualification,
        MechanicSpecialization specialization,
        int experienceYears)
    {
        string validatedFullName = Guard.RequireText(fullName, "ФИО механика");
        QualificationLevel validatedQualification = Guard.RequireDefined(qualification, "Квалификация");
        int validatedExperienceYears = ValidateExperience(experienceYears);
        FullName = validatedFullName;
        Qualification = validatedQualification;
        Specialization = specialization;
        ExperienceYears = validatedExperienceYears;
    }

    private static int ValidateExperience(int experienceYears)
    {
        Guard.RequireNonNegative(experienceYears, "Стаж");
        if (experienceYears > MaxExperienceYears)
        {
            throw new ArgumentException($"Стаж не может превышать {MaxExperienceYears} лет.");
        }

        return experienceYears;
    }
}

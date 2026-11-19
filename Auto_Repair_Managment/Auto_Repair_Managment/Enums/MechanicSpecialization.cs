namespace Auto_Repair_Managment.Enums;

[Flags]
public enum MechanicSpecialization
{
    None = 0,

    Engine = 1,

    Transmission = 2,

    Electrics = 4,

    Suspension = 8,

    Bodywork = 16
}

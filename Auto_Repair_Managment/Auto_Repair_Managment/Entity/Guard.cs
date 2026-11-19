using System.Numerics;

namespace Auto_Repair_Managment.Entity;

internal static class Guard
{
    public static string RequireText(string? value, string fieldTitle, int maxLength = 200)
    {
        ArgumentNullException.ThrowIfNull(value);
        string trimmedValue = value.Trim();
        if (trimmedValue.Length == 0)
        {
            throw new ArgumentException($"Поле «{fieldTitle}» не заполнено.");
        }

        if (trimmedValue.Length > maxLength)
        {
            throw new ArgumentException($"Поле «{fieldTitle}» не должно быть длиннее {maxLength} символов.");
        }

        return trimmedValue;
    }

    public static int RequireSelected(int id, string fieldTitle)
    {
        if (id <= 0)
        {
            throw new ArgumentException($"Не выбрано значение поля «{fieldTitle}».");
        }

        return id;
    }

    public static T RequirePositive<T>(T value, string fieldTitle) where T : INumber<T>
    {
        if (value <= T.Zero)
        {
            throw new ArgumentException($"Значение поля «{fieldTitle}» должно быть больше нуля.");
        }

        return value;
    }

    public static T RequireNonNegative<T>(T value, string fieldTitle) where T : INumber<T>
    {
        if (value < T.Zero)
        {
            throw new ArgumentException($"Значение поля «{fieldTitle}» не может быть отрицательным.");
        }

        return value;
    }

    public static TEnum RequireDefined<TEnum>(TEnum value, string fieldTitle) where TEnum : struct, Enum
    {
        if (!Enum.IsDefined(value))
        {
            throw new ArgumentException($"Не выбрано значение поля «{fieldTitle}».");
        }

        return value;
    }
}

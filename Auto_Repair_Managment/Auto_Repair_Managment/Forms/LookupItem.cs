namespace Auto_Repair_Managment.Forms;

public sealed class LookupItem<TValue> where TValue : notnull
{
    public string Text { get; }

    public TValue Value { get; }

    public LookupItem(string text, TValue value)
    {
        ArgumentNullException.ThrowIfNull(text);
        ArgumentNullException.ThrowIfNull(value);
        Text = text;
        Value = value;
    }

    public override string ToString()
    {
        return Text;
    }
}

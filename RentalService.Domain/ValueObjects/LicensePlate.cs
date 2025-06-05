using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalService.Domain.ValueObjects;
public readonly struct LicensePlate
{
    public string Value { get; } = string.Empty;

    public LicensePlate(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length != 7)
            throw new ArgumentException("Invalid License Plate Value.");
        Value = value.ToUpper();
    }

    public override string ToString() => Value;
}

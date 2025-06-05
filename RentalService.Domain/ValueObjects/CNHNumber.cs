using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalService.Domain.ValueObjects;
public readonly struct CNHNumber
{
    public string Value { get; } = string.Empty;
    public CNHNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length != 11)
            throw new ArgumentException("Invalid CNH Number Value.");
        Value = value;
    }
    public override string ToString() => Value;
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalService.Domain.ValueObjects;
public readonly struct CNPJ
{
    public string Value { get; } = string.Empty;
    public CNPJ(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length != 14)
            throw new ArgumentException("Invalid CNPJ Value.");
        Value = value;
    }
    public override string ToString() => Value;
}


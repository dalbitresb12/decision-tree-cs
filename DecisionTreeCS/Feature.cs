using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTreeCS {
  class Feature {
    public dynamic Value {
      get; private set;
    }

    public bool IsNumeric => Value is decimal;

    public Feature(string value) => Value = value;
    public Feature(decimal value) => Value = value;

    public override int GetHashCode() {
      if (Value is decimal number)
        return number.GetHashCode();
      else if (Value is string str)
        return str.GetHashCode();
      else
        return base.GetHashCode();
    }

    public override bool Equals(object obj) {
      if (obj is Feature feature) {
        if (Value is decimal number)
          return number.Equals(feature.Value);
        else if (Value is string str)
          return str.Equals(feature.Value);
      }
      return base.Equals(obj);
    }

    public override string ToString() {
      if (Value is decimal number)
        return number.ToString();
      else
        return Value;
    }

    public static Feature ParseFromCsv(dynamic feature) {
      // Try casting (this might fail, an outer try-catch block should prevent the app from dying)
      string value = feature.Value as string;

      // Try parsing the value as a number, if successful use that 
      if (decimal.TryParse(value, out decimal num))
        return new Feature(num);
      // If parsing as number wasn't successful, use it as-is
      else
        return new Feature(value);
    }
  }
}

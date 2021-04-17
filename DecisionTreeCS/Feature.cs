using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTreeCS {
  class Feature {
    public string Name {
      get; set;
    }
    public dynamic Value {
      get; set;
    }

    public bool IsNumeric => Value is decimal;

    public Feature(string name, dynamic value) {
      Name = name;
      Value = value;
    }

    public static Feature ParseFeatureFromCsv(dynamic feature) {
      // Try casting (this might fail, an outer try-catch block should prevent the app from dying)
      string name = feature.Key as string;
      string value = feature.Value as string;

      // Try parsing the value as a number, if successful use that 
      if (decimal.TryParse(value, out decimal num))
        return new Feature(name, num);
      // If parsing as number wasn't successful, use it as-is
      else
        return new Feature(name, value);
    }
  }
}

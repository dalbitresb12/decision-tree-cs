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
  }
}

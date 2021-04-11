using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTreeCS {
  class Feature {
    public string Name {
      get;
      private set;
    }
    public dynamic Value {
      get;
      private set;
    }

    public bool IsNumeric => Value is decimal || Value is int || Value is float || Value is double;

    public Feature(string name, dynamic value) {
      Name = name;
      Value = value;
    }
  }
}

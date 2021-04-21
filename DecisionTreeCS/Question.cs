using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTreeCS {
  class Question {
    readonly int property;
    readonly string propertyName;
    readonly Feature feature;

    public Question(int property, string propertyName, Feature feature) {
      this.property = property;
      this.propertyName = propertyName;
      this.feature = feature;
    }

    public bool Match(Row row) {
      Feature feature = row[property];
      if (feature.IsNumeric && this.feature.IsNumeric) {
        return feature.Value >= this.feature.Value;
      }
      return feature.Value == this.feature.Value;
    }

    public override string ToString() {
      if (feature.IsNumeric) {
        return $"¿Es {propertyName.FirstCharToLower()} >= {feature.Value}?";
      } else {
        return $"¿Es {propertyName.FirstCharToLower()} == {feature.Value}?";
      }
    }
  }
}

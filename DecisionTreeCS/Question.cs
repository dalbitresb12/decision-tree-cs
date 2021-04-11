using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTreeCS {
  class Question {
    readonly ExampleProperty property;
    readonly string value;

    public Question(ExampleProperty property, string value) {
      this.property = property;
      this.value = value;
    }

    public bool Match(ParsedExample example) {
      string exampleValue = example.GetProperty(property);
      return value == exampleValue;
    }

    override public string ToString() {
      string propertyName = Enum.GetName(typeof(ExampleProperty), property);
      return $"Is ${propertyName} == ${value}?";
    }
  }
}

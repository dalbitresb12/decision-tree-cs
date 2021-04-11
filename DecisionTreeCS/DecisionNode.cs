using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTreeCS {
  class DecisionNode {
    public readonly Question question = null;
    public readonly DecisionNode trueBranch = null;
    public readonly DecisionNode falseBranch = null;
    public readonly List<ParsedExample> rows = null;
    public readonly Dictionary<string, int> predictions = null;

    public bool IsLeaf => predictions != null;

    public DecisionNode(Question question, DecisionNode trueBranch, DecisionNode falseBranch) {
      this.question = question;
      this.trueBranch = trueBranch;
      this.falseBranch = falseBranch;
    }

    public DecisionNode(List<ParsedExample> examples) {
      rows = examples;
      predictions = DecisionTree.GetClassCount(examples);
    }

    override public string ToString() {
      if (IsLeaf) {
        double total = predictions.Aggregate(0.0, (acc, x) => acc + x.Value);
        string str = "{ ";
        foreach (KeyValuePair<string, int> value in predictions) {
          int percent = (int)Math.Round(value.Value / total * 100, 0);
          str += $"'{value.Key}': {percent}%, ";
        }
        str = str.Remove(str.Length - 2);
        str += " }";
        return str;
      }

      return question.ToString();
    }
  }
}

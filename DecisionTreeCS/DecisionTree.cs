using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTreeCS {
  class DecisionTree {
    List<ParsedExample> examples;
    DecisionNode root;

    public void Fit(List<ParsedExample> examples) {
      this.examples = examples;
      root = BuildTree(examples);
    }

    static DecisionNode BuildTree(List<ParsedExample> rows) {
      (double gain, Question question) = FindBestSplit(rows);

      if (gain == 0)
        return new DecisionNode(rows);

      (List<ParsedExample> trueRows, List<ParsedExample> falseRows) = PartitionDataset(rows, question);

      DecisionNode trueBranch = BuildTree(trueRows);
      DecisionNode falseBranch = BuildTree(falseRows);

      return new DecisionNode(question, trueBranch, falseBranch);
    }

    public DecisionNode Predict(ParsedExample row, DecisionNode node = null) {
      if (node == null)
        node = root;

      if (node.IsLeaf)
        return node;

      if (node.question.Match(row))
        return Predict(row, node.trueBranch);

      return Predict(row, node.falseBranch);
    }

    public static HashSet<string> FindUniqueValues(List<ParsedExample> rows, ExampleProperty col) {
      HashSet<string> values = new HashSet<string>();
      foreach (ParsedExample row in rows) {
        _ = values.Add(row.GetProperty(col));
      }
      return values;
    }

    public static Dictionary<string, int> GetClassCount(List<ParsedExample> rows) {
      Dictionary<string, int> counts = new Dictionary<string, int>();
      foreach (ParsedExample row in rows) {
        string label = row.isGame;
        if (!counts.ContainsKey(label)) {
          counts[label] = 0;
        }
        counts[label] += 1;
      }
      return counts;
    }

    public static (List<ParsedExample> trueRows, List<ParsedExample> falseRows) PartitionDataset(List<ParsedExample> rows, Question question) {
      List<ParsedExample> trueRows = new List<ParsedExample>();
      List<ParsedExample> falseRows = new List<ParsedExample>();
      foreach (ParsedExample row in rows) {
        if (question.Match(row))
          trueRows.Add(row);
        else
          falseRows.Add(row);
      }
      return (trueRows, falseRows);
    }

    public static double CalculateGini(List<ParsedExample> rows) {
      Dictionary<string, int> counts = GetClassCount(rows);
      double impurity = 1;
      foreach (KeyValuePair<string, int> label in counts) {
        double probability = Convert.ToDouble(label.Value) / Convert.ToDouble(rows.Count);
        impurity -= Math.Pow(probability, 2);
      }
      return impurity;
    }

    public static double CalculateInfoGain(List<ParsedExample> left, List<ParsedExample> right, double current) {
      double avg = Convert.ToDouble(left.Count) / Convert.ToDouble(left.Count + right.Count);
      return current - (avg * CalculateGini(left) + (1 - avg) * CalculateGini(right));
    }

    public static (double gain, Question question) FindBestSplit(List<ParsedExample> rows) {
      double bestGain = 0;
      Question bestQuestion = null;
      double currentGini = CalculateGini(rows);
      int featureCount = rows[0].GetFeaturesCount();

      for (int i = 0; i < featureCount; ++i) {
        ExampleProperty property = (ExampleProperty)i;
        HashSet<string> values = FindUniqueValues(rows, property);

        foreach (string val in values) {
          Question question = new Question(property, val);
          (List<ParsedExample> trueRows, List<ParsedExample> falseRows) = PartitionDataset(rows, question);
          if (trueRows.Count == 0 || falseRows.Count == 0)
            continue;
          double gain = CalculateInfoGain(trueRows, falseRows, currentGini);
          if (gain > bestGain) {
            bestGain = gain;
            bestQuestion = question;
          }
        }
      }

      return (bestGain, bestQuestion);
    }
  }
}

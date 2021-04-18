using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTreeCS {
  class DecisionTree {
    Dataset dataset;
    DecisionNode root;

    public void Fit(Dataset dataset) {
      this.dataset = dataset;
      root = BuildTree(dataset);
    }

    public DecisionNode Predict(Row row, DecisionNode node = null) {
      if (node == null)
        node = root;

      if (node.IsLeaf)
        return node;

      if (node.question.Match(row))
        return Predict(row, node.trueBranch);

      return Predict(row, node.falseBranch);
    }

    private static DecisionNode BuildTree(Dataset dataset) {
      (double gain, Question question) = FindBestSplit(dataset);

      if (gain == 0)
        return new DecisionNode(dataset);

      (Dataset trueRows, Dataset falseRows) = PartitionDataset(dataset, question);

      DecisionNode trueBranch = BuildTree(trueRows);
      DecisionNode falseBranch = BuildTree(falseRows);

      return new DecisionNode(question, trueBranch, falseBranch);
    }

    public static Dictionary<string, int> GetClassCount(Dataset dataset) {
      Dictionary<string, int> counts = new Dictionary<string, int>();
      foreach (Row row in dataset) {
        string label = row[row.Count - 1].ToString();
        if (!counts.ContainsKey(label))
          counts[label] = 0;
        counts[label] += 1;
      }
      return counts;
    }

    public static (Dataset trueRows, Dataset falseRows) PartitionDataset(Dataset dataset, Question question) {
      Dataset trueRows = new Dataset(dataset.Headers);
      Dataset falseRows = new Dataset(dataset.Headers);
      foreach (Row row in dataset) {
        if (question.Match(row))
          trueRows.Add(row);
        else
          falseRows.Add(row);
      }
      return (trueRows, falseRows);
    }

    public static double CalculateGini(Dataset dataset) {
      Dictionary<string, int> counts = GetClassCount(dataset);
      double impurity = 1;
      foreach (KeyValuePair<string, int> label in counts) {
        double probability = Convert.ToDouble(label.Value) / Convert.ToDouble(dataset.Count);
        impurity -= Math.Pow(probability, 2);
      }
      return impurity;
    }

    public static double CalculateInfoGain(Dataset left, Dataset right, double current) {
      double avg = Convert.ToDouble(left.Count) / Convert.ToDouble(left.Count + right.Count);
      return current - (avg * CalculateGini(left) + (1 - avg) * CalculateGini(right));
    }

    public static (double gain, Question question) FindBestSplit(Dataset dataset) {
      double bestGain = 0;
      Question bestQuestion = null;
      double currentGini = CalculateGini(dataset);
      int featureCount = dataset.MaxFeatureCount;

      for (int i = 0; i < featureCount; ++i) {
        HashSet<Feature> features = dataset.GetUniqueValues(i);

        foreach (Feature feature in features) {
          Question question = new Question(i, dataset.Headers[i], feature);
          (Dataset trueRows, Dataset falseRows) = PartitionDataset(dataset, question);
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

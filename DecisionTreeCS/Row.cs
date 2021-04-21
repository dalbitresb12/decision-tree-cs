using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTreeCS {
  class Row : IEnumerable<Feature> {
    readonly List<Feature> features;

    public Row(List<Feature> features = null) {
      if (features == null)
        this.features = new List<Feature>();
      else
        this.features = features;
    }

    public int Count => features.Count;

    public void Add(Feature item) => features.Add(item);

    public void AddRange(IEnumerable<Feature> collection) => features.AddRange(collection);

    public void Clear() => features.Clear();

    public Feature this[int index] {
      get => features[index];
      set => features[index] = value;
    }

    public static Row ParseFromCsv(dynamic record) {
      if (record is IEnumerable enumerable) {
        Row row = new Row();
        // This will probably be a Dictionary<string, string>,
        // therefore, feature should be KeyValuePair<string, string>.
        foreach (var feature in enumerable) {
          // Try parsing this record as a feature
          Feature parsedFeature = Feature.ParseFromCsv(feature);
          // If successful, add it to the feature list
          if (parsedFeature != null)
            row.Add(parsedFeature);
        }
        return row;
      }

      return null;
    }

    public IEnumerator<Feature> GetEnumerator() => features.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
  }
}

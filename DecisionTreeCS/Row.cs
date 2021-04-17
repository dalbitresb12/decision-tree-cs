﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTreeCS {
  class Row: IEnumerable<Feature> {
    readonly List<Feature> features;

    public Row(List<Feature> features = null) {
      if (features == null)
        this.features = new List<Feature>();
      else
        this.features = features;
    }

    public int Count => features.Count;

    public void Add(Feature item) => features.Add(item);

    public Feature this[int index] {
      get => features[index];
      set => features.Insert(index, value);
    }

    public static Row ParseRowFromCsv(dynamic record) {
      Row row = new Row();
      // This will probably be a Dictionary<string, string>,
      // therefore, feature should be KeyValuePair<string, string>.
      foreach (var feature in record) {
        // Try parsing this record as a feature
        Feature parsedFeature = Feature.ParseFeatureFromCsv(feature);
        // If successful, add it to the feature list
        if (parsedFeature != null)
          row.Add(parsedFeature);
      }
      return row;
    }

    public IEnumerator<Feature> GetEnumerator() => features.GetEnumerator();

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() =>
      GetEnumerator();
  }
}
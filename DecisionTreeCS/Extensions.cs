using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTreeCS {
  public static class StringExtensions {
    public static string FirstCharToUpper(this string input) {
      if (string.IsNullOrEmpty(input))
        return string.Empty;

      char[] str = input.ToCharArray();
      str[0] = char.ToUpper(str[0]);
      return new string(str);
    }

    public static string FirstCharToLower(this string input) {
      if (string.IsNullOrEmpty(input))
        return string.Empty;

      char[] str = input.ToCharArray();
      str[0] = char.ToLower(str[0]);
      return new string(str);
    }
  }
}

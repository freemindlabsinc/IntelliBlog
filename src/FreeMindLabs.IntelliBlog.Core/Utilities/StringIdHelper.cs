using System.ComponentModel;

namespace FreeMindLabs.IntelliBlog.Core.Utilities;

public static class StrongIdHelper<TId, TValue> where TId : struct
{
  public static string Serialize(TValue value) =>
      $"{GetPrefix(typeof(TId).Name)}-{value?.ToString()?.ToLower() ?? string.Empty}";

  public static TId? Deserialize(string? id, Func<string, string> valuePreprocess)
  {
    if (id is null) return null;

    string prefix = GetPrefix(typeof(TId).Name) + "-";
    if (!id.StartsWith(prefix)) return null;

    string rawValue = valuePreprocess(id[prefix.Length..]);

    try
    {
      if (TypeDescriptor.GetConverter(typeof(TValue)).ConvertFromString(rawValue) is TValue value)
        return (TId?)Activator.CreateInstance(typeof(TId), value);
    }
    catch { }
    return null;
  }

  public static TId? Deserialize(string? id) => Deserialize(id, x => x);


  private static string GetPrefix(string typeName) =>
      (typeName.EndsWith("Id") ? typeName[..^2] : typeName).ToLower();
}

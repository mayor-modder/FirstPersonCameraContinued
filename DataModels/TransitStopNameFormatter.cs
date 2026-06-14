using System;

namespace FirstPersonCameraContinued.DataModels
{
    public static class TransitStopNameFormatter
    {
        public const string DefaultStopName = "Stop";

        public static string ChooseStopName(params string?[] candidates)
        {
            foreach (string? candidate in candidates)
            {
                string normalized = NormalizeDisplayName(candidate);
                if (!string.IsNullOrEmpty(normalized))
                    return normalized;
            }

            return DefaultStopName;
        }

        public static string NormalizeDisplayName(string? name)
        {
            if (name == null)
                return "";

            if (string.IsNullOrWhiteSpace(name))
                return "";

            string trimmedName = name.Trim();
            return IsRawAssetLocalizationName(trimmedName) ? "" : trimmedName;
        }

        private static bool IsRawAssetLocalizationName(string name)
        {
            return name.StartsWith("Assets.NAME[", StringComparison.OrdinalIgnoreCase)
                && name.EndsWith("]", StringComparison.Ordinal);
        }
    }
}

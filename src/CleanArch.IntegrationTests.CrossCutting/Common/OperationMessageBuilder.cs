using System.Runtime.CompilerServices;
using System.Text;

namespace CleanArch.IntegrationTests.CrossCutting.Common
{
    public class OperationMessageBuilder
    {
        private readonly string _source;
        private readonly string _method;

        public OperationMessageBuilder(object sourceInstance, [CallerMemberName] string method = "")
        {
            _source = sourceInstance.GetType().Name;
            _method = method;
        }

        public OperationMessage Info(int spec, string description)
            => new(BuildCode("INF", spec), description);

        public OperationMessage BusinessError(int spec, string description)
            => new(BuildCode("BUS", spec), description);

        public OperationMessage SystemError(int spec, string description)
            => new(BuildCode("SYS", spec), description);

        private string BuildCode(string prefix, int spec)
        {
            return $"{prefix}-{ExtractAbbr(_source)}-{ExtractAbbr(_method)}-{spec}";
        }

        private static string ExtractAbbr(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;

            var abbr = new StringBuilder();
            foreach (var c in input.Where(char.IsUpper))
            {
                abbr.Append(c);
                if (abbr.Length >= 3) break;
            }

            return abbr.ToString();
        }
    }
}

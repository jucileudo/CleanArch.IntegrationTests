namespace CleanArch.IntegrationTests.CrossCutting.Common
{
    
        public class OperationMessage
        {
            public string Code { get; }
            public string Description { get; }

            public OperationMessage(string code, string description)
            {
                Code = code;
                Description = description;
            }
        }
    }



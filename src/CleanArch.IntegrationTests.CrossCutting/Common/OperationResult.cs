namespace CleanArch.IntegrationTests.CrossCutting.Common
{
            public class OperationResult
        {
            public bool IsSuccessful { get; }
            public List<OperationMessage> Messages { get; }

            public OperationResult(bool isSuccessful, OperationMessage message = null)
            {
                IsSuccessful = isSuccessful;
                Messages = new List<OperationMessage>();
                if (message != null) Messages.Add(message);
            }

            public OperationResult(bool isSuccessful, IEnumerable<OperationMessage> messages)
            {
                IsSuccessful = isSuccessful;
                Messages = messages?.ToList() ?? new List<OperationMessage>();
            }

            public void AddMessage(string code, string description)
            {
                Messages.Add(new OperationMessage(code, description));
            }
        }

        public class OperationResult<T> : OperationResult
        {
            public T Data { get; }

            public OperationResult(bool isSuccessful, T data, IEnumerable<OperationMessage> messages = null)
                : base(isSuccessful, messages)
            {
                Data = data;
            }

            public OperationResult(OperationResult baseResult, T data = default)
                : base(baseResult.IsSuccessful, baseResult.Messages)
            {
                Data = data;
            }
        }
    }



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
	public class CommandResponse
	{
		public bool Success { get; set; }
		public dynamic Result { get; set; }
		public ValidationResult ValidationResult { get; set; }

		public string ErrorMessage { get; set; }
	}
	public class ValidationResult
	{
		public List<ValidationFailure> Errors { get; set; }
		public bool IsValid => !Errors.Any();

		public ValidationResult()
		{
			Errors = new List<ValidationFailure>();
		}

		public ValidationResult(List<ValidationFailure> errors)
		{
			Errors = errors;
		}

		public void AddError(string errorMessage, string propertyName = "", string errorCode = "", string resourceName = "")
		{
			Errors.Add(new ValidationFailure
			{
				ErrorMessage = errorMessage,
				PropertyName = propertyName,
				ErrorCode = errorCode,
				ResourceName = resourceName
			});
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (ValidationFailure error in Errors)
			{
				if (!string.IsNullOrEmpty(stringBuilder.ToString()))
				{
					stringBuilder.Append(",\n");
				}
				stringBuilder.Append(error.ErrorMessage);
			}
			return stringBuilder.ToString();
		}
	}
	public class ValidationFailure
	{
		public string ErrorCode { get; set; }

		public string ErrorMessage { get; set; }
		public string PropertyName { get; set; }
		public string ResourceName { get; set; }
	}

	public class QueryResponse<TResult>
	{
		public bool Success { get; set; }

		public TResult Data { get; set; }

		public int TotalCount { get; set; }

		public ValidationResult ValidationResult { get; set; }

		public string ErrorMessage { get; set; }
	}

}

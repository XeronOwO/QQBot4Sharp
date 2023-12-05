using QQBot4Sharp.Internal.API;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Exceptions
{
	/// <summary>
	/// API异常
	/// </summary>
	public class APIException : Exception
	{
		/// <inheritdoc/>
		public APIException() : base()
		{

		}

		/// <inheritdoc/>
		public APIException(string message) : base(message)
		{

		}

		/// <inheritdoc/>
		public APIException(string message, Exception innerException) : base(message, innerException)
		{

		}

		/// <summary>
		/// 错误码
		/// </summary>
		public int Code { get; }

		/// <summary>
		/// 错误信息
		/// </summary>
		public string Msg { get; }

		internal APIException(int code, string message) : base($"API响应异常：[{code}]{message}")
		{
			Code = code;
			Msg = message;
		}

		internal APIException(int code, string message, Exception innerException) : base($"API响应异常：[{code}]{message}", innerException)
		{
			Code = code;
			Msg = message;
		}
	}
}

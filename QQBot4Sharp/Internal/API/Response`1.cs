using Newtonsoft.Json;

namespace QQBot4Sharp.Internal.API
{
	internal struct Response<T>
	{
		[JsonProperty("code")]
		public int Code;

		[JsonProperty("message")]
		public string Message;

		[JsonIgnore]
		public bool IsSuccess => Code == 0;

		[JsonProperty("data")]
		public T Data;

		public static implicit operator T(Response<T> response) => response.Data;
	}
}

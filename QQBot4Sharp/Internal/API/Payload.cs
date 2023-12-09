using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Internal.API
{
	internal struct Payload
	{
		/// <summary>
		/// 操作码
		/// </summary>
		[JsonProperty("op")]
		public OpCode OpCode;

		/// <summary>
		/// 代表事件内容，不同事件类型的事件内容格式都不同，请注意识别。主要是用在op为 0 Dispatch 的时候
		/// </summary>
		[JsonProperty("d")]
		public JToken Data;

		/// <summary>
		/// 下行消息都会有一个序列号，标识消息的唯一性，客户端需要再发送心跳的时候，携带客户端收到的最新的s
		/// </summary>
		[JsonProperty("s")]
		public int? Seq;

		/// <summary>
		/// 代表事件类型。主要是用在op为 0 Dispatch 的时候
		/// </summary>
		[JsonProperty("t")]
		public string Type;

		public Payload<T> Cast<T>()
		{
			return new()
			{
				OpCode = OpCode,
				Data = JsonConvert.DeserializeObject<T>(Data.ToString(Formatting.None)),
				Seq = Seq,
				Type = Type,
			};
		}
	}
}

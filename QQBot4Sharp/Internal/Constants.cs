using System;
using System.Collections.Generic;
using System.Text;

namespace QQBot4Sharp.Internal
{
	internal static class Constants
	{
		/// <summary>
		/// 时间误差，单位毫秒。由于网络状况等原因，数据包传输可能会有一定的延迟，以此为时间误差值，以缓解延迟导致的问题
		/// </summary>
		public const int TimeError = 5000;
	}
}

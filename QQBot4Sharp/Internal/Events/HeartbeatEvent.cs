using Newtonsoft.Json.Linq;
using QQBot4Sharp.Internal.API;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QQBot4Sharp.Internal.Events
{
	internal class HeartbeatEvent : Event
	{
		public override async Task HandleAsync(Payload payload)
		{
			UpdateSeq(payload.Seq);

			await Task.CompletedTask;
		}

		private int? _seq;

		public int? Seq => _seq;

		private void UpdateSeq(int? serial)
		{
			lock (this)
			{
				if (serial != null)
				{
					_seq = serial;
				}
			}
		}

		private CancellationTokenSource _cts;

		private string _sessionID;

		public string SessionID => _sessionID;

		public void Start()
			=> Start(_sessionID);

		public void Start(string sessionID)
		{
			Log.Information("开始心跳任务");

			_sessionID = sessionID;
			_cts?.Cancel();
			_cts = new();
			_ = HeartbeatTask(EventBus.Get<HelloEvent>().HeartbeatInterval - Constants.TimeError, _cts.Token);
		}

		public void Stop()
		{
			if (_cts != null)
			{
				_cts.Cancel();
				_cts = null;
			}
		}

		private async Task HeartbeatTask(int interval, CancellationToken cancellationToken)
		{
			try
			{
				while (!cancellationToken.IsCancellationRequested)
				{
					await BotWebSocket.SendMessageAsync(new Payload()
					{
						OpCode = OpCode.Heartbeat,
						Data = new JValue(_seq),
					});

					await Task.Delay(interval, cancellationToken);
				}
			}
			catch (TaskCanceledException)
			{
				Log.Information("心跳任务被取消");
			}
			catch (Exception e)
			{
				Log.Error(e, "心跳任务异常退出");
			}
		}

		public override void Dispose()
		{
			base.Dispose();

			if (_cts != null)
			{
				_cts.Cancel();
				_cts = null;
			}
		}
	}
}

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
	internal class ReadyEvent : Event
	{
		public ReadyEvent()
		{

		}

		public override async Task HandleAsync(Payload payload)
		{
			UpdateSerial(payload);
			if (payload.OpCode != OpCode.Dispatch)
			{
				return;
			}
			if (payload.Type != "READY")
			{
				return;
			}

			OnReady(payload.Cast<ReadyRes>());

			await Task.CompletedTask;
		}

		private int? _serial;

		private void UpdateSerial(Payload payload)
		{
			lock (this)
			{
				if (payload.Serial != null)
				{
					_serial = payload.Serial;
				}
			}
		}

		private CancellationTokenSource _cts;

		private async void OnReady(Payload<ReadyRes> payload)
		{
			Log.Information("鉴权成功，开始心跳任务");

			_cts?.Cancel();
			_cts = new();
			_ = HeartbeatTask(EventBus.Get<HelloEvent>().HeartbeatInterval - Constants.TimeError, _cts.Token);

			await BotService.SendReadyEventAsync(new(BotContext));
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
						Data = new JValue(_serial),
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

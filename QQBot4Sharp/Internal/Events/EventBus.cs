using QQBot4Sharp.Internal.API;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QQBot4Sharp.Internal.Events
{
    internal class EventBus : IDisposable
	{
		private readonly BotWebSocket _botWebSocket;

		public BotWebSocket BotWebSocket => _botWebSocket;

		private readonly List<Event> _events;

		public List<Event> Events => _events;

		public EventBus(BotWebSocket botWebSocket)
		{
			_botWebSocket = botWebSocket;
			_events = new();
		}

		public Event Add(Type type)
		{
			if (type.BaseType != typeof(Event))
			{
				throw new Exception("类型必须继承自Event");
			}
			var @event = (Event)Activator.CreateInstance(type);
			@event.EventBus = this;
			lock (this)
			{
				_events.Add(@event);
			}
			return @event;
		}

		public T Get<T>() where T : Event
		{
			lock (this)
			{
				foreach (var @event in _events)
				{
					if (@event is T t)
					{
						return t;
					}
				}

				return null;
			}
		}

		public void Remove<T>() where T : Event
		{
			lock (this)
			{
				foreach (var @event in _events.ToArray())
				{
					if (@event is T)
					{
						_events.Remove(@event);
						@event.Dispose();
						return;
					}
				}
			}
		}

		public void RemoveAll<T>() where T : Event
		{
			lock (this)
			{
				foreach (var @event in _events.ToArray())
				{
					if (@event is T)
					{
						_events.Remove(@event);
						@event.Dispose();
					}
				}
			}
		}

		public void Remove(Event @event)
		{
			lock (this)
			{
				_events.Remove(@event);
			}
		}

		public async Task DispatchAsync(Payload payload)
		{
			foreach (var @event in _events.ToArray())
			{
				await @event.HandleAsync(payload);
			}
		}

		public void Dispose()
		{
			foreach (var @event in _events)
			{
				@event.Dispose();
			}
			_events.Clear();
		}
	}
}

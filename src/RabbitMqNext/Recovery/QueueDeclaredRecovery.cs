﻿namespace RabbitMqNext.Recovery
{
	using System;
	using System.Collections.Generic;

	internal class QueueDeclaredRecovery
	{
		private readonly string _queue;
		private readonly bool _passive;
		private readonly bool _durable;
		private readonly bool _exclusive;
		private readonly bool _autoDelete;
		private readonly IDictionary<string, object> _arguments;

		public QueueDeclaredRecovery(string queue, bool passive, bool durable, bool exclusive, bool autoDelete, IDictionary<string, object> arguments)
			: this(queue)
		{
			_passive = passive;
			_durable = durable;
			_exclusive = exclusive;
			_autoDelete = autoDelete;
			_arguments = arguments;
		}

		public QueueDeclaredRecovery(string queue)
		{
			_queue = queue;
		}

		protected bool Equals(QueueDeclaredRecovery other)
		{
			return StringComparer.Ordinal.Equals(_queue, other._queue);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((QueueDeclaredRecovery) obj);
		}

		public override int GetHashCode()
		{
			return (_queue != null ? _queue.GetHashCode() : 0);
		}
	}
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using GladNet;
using JetBrains.Annotations;
using SceneJect.Common;

namespace Booma.Proxy
{
	/// <summary>
	/// Default payload handler that can handle all payload types
	/// and logs information about the message.
	/// </summary>
	/// <typeparam name="TPayloadType"></typeparam>
	/// <typeparam name="TOutgoingPayloadType"></typeparam>
	[Injectee]
	public sealed class DefaultPayloadHandler<TPayloadType, TOutgoingPayloadType> : IPeerPayloadSpecificMessageHandler<TPayloadType, TOutgoingPayloadType> 
		where TPayloadType : class 
		where TOutgoingPayloadType : class
	{
		[Inject]
		private ILog Logger { get; }

		/// <inheritdoc />
		public DefaultPayloadHandler(ILog logger)
		{
			if(logger == null) throw new ArgumentNullException(nameof(logger));

			Logger = logger;
		}

		/// <inheritdoc />
		public Task HandleMessage(IPeerMessageContext<TOutgoingPayloadType> context, TPayloadType payload)
		{
			if(context == null) throw new ArgumentNullException(nameof(context));
			if(payload == null) throw new ArgumentNullException(nameof(payload));

			//TODO: We can disconnect if we encounter unknowns or do more indepth logging/decisions
			if(Logger.IsInfoEnabled)
				if(payload is IUnknownPayloadType unk)
					Logger.Info(unk.ToString());
				else
					Logger.Info($"Recieved unhandled payload of Type: {payload.GetType().Name} Info: {payload}");

			return Task.CompletedTask;
		}
	}
}

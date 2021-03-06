﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using GladNet;
using SceneJect.Common;

namespace Booma.Proxy
{
	[SceneTypeCreate(GameSceneType.Pioneer2)]
	[SceneTypeCreate(GameSceneType.RagolDefault)]
	public sealed class BlockOtherPlayerLeaveGameEventPayloadHandler : GameMessageHandler<BlockOtherPlayerLeaveGameEventPayload>
	{
		private INetworkEntityRegistery<INetworkPlayer> PlayerRegistry { get; }

		/// <inheritdoc />
		public BlockOtherPlayerLeaveGameEventPayloadHandler([NotNull] INetworkEntityRegistery<INetworkPlayer> playerRegistry, ILog logger) 
			: base(logger)
		{
			PlayerRegistry = playerRegistry ?? throw new ArgumentNullException(nameof(playerRegistry));
		}

		/// <inheritdoc />
		public override Task HandleMessage(IPeerMessageContext<PSOBBGamePacketPayloadClient> context, BlockOtherPlayerLeaveGameEventPayload payload)
		{
			//TODO: We can't check that we have this spawned, so we should address that.
			INetworkPlayer player = PlayerRegistry.RemoveEntity(payload.Identifier);

			if(player == null)
			{
				Logger.Warn($"Recieved GameLeave for unknown Client: {payload.Identifier}.");
				return Task.CompletedTask;
			}

			player.Despawn();

			return Task.CompletedTask;
		}
	}
}

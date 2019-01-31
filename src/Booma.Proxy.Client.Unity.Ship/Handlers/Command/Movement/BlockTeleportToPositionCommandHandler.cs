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
	[SceneTypeCreate(GameSceneType.LobbyDefault)]
	public sealed class BlockTeleportToPositionCommandHandler : ContextExtendedCommand60Handler<Sub60TeleportToPositionCommand, INetworkPlayerNetworkMessageContext>
	{
		private IUnitScalerStrategy ScalerService { get; }

		/// <inheritdoc />
		public BlockTeleportToPositionCommandHandler([NotNull] IUnitScalerStrategy scalerService, ILog logger, INetworkMessageContextFactory<IMessageContextIdentifiable, INetworkPlayerNetworkMessageContext> contextFactory)
			: base(logger, contextFactory)
		{
			ScalerService = scalerService ?? throw new ArgumentNullException(nameof(scalerService));
		}

		/// <inheritdoc />
		protected override Task HandleSubMessage(IPeerMessageContext<PSOBBGamePacketPayloadClient> context, Sub60TeleportToPositionCommand command, INetworkPlayerNetworkMessageContext commandContext)
		{
			//TODO: Don't do anything with this
			if(Logger.IsInfoEnabled)
				Logger.Info($"Recieved {nameof(Sub60TeleportToPositionCommand)} ClientId: {command.Identifier} X: {command.Position.X} Y: {command.Position.Y} Z: {command.Position.Z}");

			//This is a teleport, we should probably handle it differently than we currently do or will treat it like
			//a normal diff in position
			commandContext.RemotePlayer.Transform.Position = ScalerService.Scale(command.Position);

			return Task.CompletedTask;
		}
	}
}

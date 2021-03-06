﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace Booma.Proxy
{
	/// <summary>
	/// Packet sent by the client to request a lobby change.
	/// The server responds with 95 or 01.
	/// </summary>
	[WireDataContract]
	[GameClientPacketPayload(GameNetworkOperationCode.LOBBY_CHANGE_TYPE)]
	public sealed class BlockLobbyChangeRequestPayload : PSOBBGamePacketPayloadClient
	{
		/// <summary>
		/// The menu selection involved with the lobby change
		/// request.
		/// </summary>
		[WireMember(1)]
		public MenuItemIdentifier Selecion { get; }

		/// <inheritdoc />
		public BlockLobbyChangeRequestPayload([NotNull] MenuItemIdentifier selecion)
		{
			if(selecion == null) throw new ArgumentNullException(nameof(selecion));

			Selecion = selecion;
		}

		//Serializer ctor
		private BlockLobbyChangeRequestPayload()
		{
			
		}
	}
}

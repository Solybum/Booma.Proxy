﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreecraftCore.Serializer;

namespace Booma.Proxy
{
	/// <summary>
	/// Payload sent to request a chunk of the guild card data.
	/// </summary>
	[WireDataContract]
	[GameClientPacketPayload(GameNetworkOperationCode.BB_GUILDCARD_CHUNK_REQ_TYPE)]
	public sealed class CharacterGuildCardChunkRequestPayload : PSOBBGamePacketPayloadClient, IChunkRequest
	{
		//Tethella does this check on the unk for some reason.
		//if ((client->decryptbuf[0x08] == 0x01) && (client->decryptbuf[0x10] == 0x01))

		//TODO: What is this?
		[WireMember(1)]
		private int unk { get; } = 1; //this is 0x08

		/// <summary>
		/// The chunk number to request for
		/// the guild card data.
		/// </summary>
		[WireMember(2)]
		public uint ChunkNumber { get; }

		//TODO: What is this?
		/// <summary>
		/// ?
		/// </summary>
		[WireMember(3)]
		public bool ShouldContinue { get; } //this is 0x10

		/// <inheritdoc />
		public CharacterGuildCardChunkRequestPayload(uint chunkNumber, bool shouldContinue)
		{
			ChunkNumber = chunkNumber;
			ShouldContinue = shouldContinue;
		}

		private CharacterGuildCardChunkRequestPayload()
		{
			
		}
	}
}

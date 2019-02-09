﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreecraftCore.Serializer;

namespace Booma.Proxy
{
	//Seems this is sent to all clients in the party after a joined player has finished bursting
	//I think clients shortly after send a 0x60 0x20 Area/Warp Ack.
	/// <summary>
	/// Sent by the server in response to a 6F being sent during bursting into a game.
	/// (no idea what is in it at the moment)
	/// </summary>
	[WireDataContract]
	[SubCommand60(SubCommand60OperationCode.GameBurstingComplete)]
	public sealed class Sub60GameBurstingCompleteEventCommand : BaseSubCommand60
	{
		//See: https://github.com/justnoxx/psobb-tethealla/blob/master/ship_server/ship_server.c#L13792
		//TODO: Investigate what this is

		//Serializer ctor
		private Sub60GameBurstingCompleteEventCommand()
		{
			
		}
	}
}

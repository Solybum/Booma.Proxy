﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreecraftCore.Serializer;
using JetBrains.Annotations;

namespace Booma.Proxy
{
	//TODO: What is this?
	/// <summary>
	/// Command sent to set position and alert other clients
	/// when they finish warping.
	/// </summary>
	[WireDataContract]
	[SubCommand60(SubCommand60OperationCode.AlertFreshlyWarpedClients)]
	public sealed class Sub60FinishedWarpAckCommand : BaseSubCommand60, IMessageContextIdentifiable
	{
		/// <inheritdoc />
		[WireMember(1)]
		public byte Identifier { get; }

		[WireMember(2)]
		private byte unusued { get; }

		/// <summary>
		/// The id for the zone that the client is in.
		/// </summary>
		[WireMember(3)]
		public int ZoneId { get; }

		/// <summary>
		/// The position the client has moved to.
		/// </summary>
		[WireMember(4)]
		public Vector3<float> Position { get; } //server should set X and Z, ignoring y.

		[WireMember(5)]
		private short RawRotation { get; set; }

		//TODO: Soly said this is rotation so we should handle it 65536f / 360f
		//[WireMember(5)]
		public float YAxisRotation => RawRotation.FromNetworkRotationToYAxisRotation();

		//There are 2 extra bytes here at the end and are FF FF
		[WireMember(6)]
		private ushort unk { get; } = ushort.MaxValue; 

		public Sub60FinishedWarpAckCommand(byte clientId, int zoneId, [NotNull] Vector3<float> position, float yAxisRotation)
			: this()
		{
			if(position == null) throw new ArgumentNullException(nameof(position));
			if(zoneId < 0) throw new ArgumentOutOfRangeException(nameof(zoneId));

			Identifier = clientId;
			ZoneId = zoneId;
			Position = position;

			RawRotation = yAxisRotation.ToNetworkRotation();
		}

		public Sub60FinishedWarpAckCommand(int clientId, int zoneId, [NotNull] Vector3<float> position, float yAxisRotation)
			: this((byte)clientId, zoneId, position, yAxisRotation)
		{

		}

		//Serializer ctor
		public Sub60FinishedWarpAckCommand()
		{
			//Calc static 32bit size
			CommandSize = 24 / 4;
		}
	}
}

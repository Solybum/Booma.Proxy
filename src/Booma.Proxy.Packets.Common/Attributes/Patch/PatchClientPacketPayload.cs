﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreecraftCore.Serializer;

namespace Booma.Proxy
{
	/// <summary>
	/// Metadata attributes that implement <see cref="WireDataContractBaseLinkAttribute"/> making
	/// it easier to safely link child payloads to their propert base type and
	/// associate with in a typesafe fashion with their network operationcode enumeration value.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public sealed class PatchClientPacketPayloadAttribute : WireDataContractBaseLinkAttribute
	{
		/// <summary>
		/// Annotates a Type with the metadata required to link its child with a base type
		/// based on the provided <see cref="opCode"/> value.
		/// </summary>
		/// <param name="opCode">The operationcode.</param>
		public PatchClientPacketPayloadAttribute(PatchNetworkOperationCodes opCode) 
			: base((int)opCode, typeof(PSOBBPatchPacketPayloadClient))
		{

		}

		//CTOR for reflection unit tests to use
		/// <summary>
		/// Annotates a Type with the metadata required to link its child with a base type
		/// based on the provided <see cref="opCode"/> value.
		/// </summary>
		/// <param name="opCode">The operationcode.</param>
		internal PatchClientPacketPayloadAttribute(int opCode)
			: base(opCode, typeof(PSOBBPatchPacketPayloadClient))
		{

		}
	}
}

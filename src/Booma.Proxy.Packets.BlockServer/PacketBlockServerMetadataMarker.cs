﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FreecraftCore.Serializer;

namespace Booma.Proxy
{
	/// <summary>
	/// Just a simple referenceable Type for reflection purposes.
	/// </summary>
	public static class PacketBlockServerMetadataMarker
	{
		public static IEnumerable<Type> SerializableTypes { get; } = typeof(PacketBlockServerMetadataMarker)
			.Assembly
			.GetTypes()
			.Where(t => t.GetCustomAttribute(typeof(WireDataContractBaseLinkAttribute)) != null)
			.ToList();
	}
}

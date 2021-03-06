﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SceneJect.Common;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Booma.Proxy
{
	/// <summary>
	/// The <see cref="INetworkEntity"/> components for the network items.
	/// </summary>
	[Injectee]
	public class GameNetworkItem : SerializedMonoBehaviour, INetworkItem
	{
		[Required]
		[Tooltip("The network transform.")]
		[OdinSerialize]
		private INetworkEntityTransform NetworkTransform;

		/// <inheritdoc />
		public INetworkEntityTransform Transform => NetworkTransform;

		/// <inheritdoc />
		[Inject]
		public IEntityIdentity Identity { get; }

		/// <inheritdoc />
		public void Despawn()
		{
			//TODO: We should probably broadcast and do some other stuff. Right now we should just delete
			Destroy(gameObject);
		}
	}
}

﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Reflect.Extent;

namespace Booma.Proxy
{
	public class AssemblyHandlerIterator<THandlerTypeProvider> : IEnumerable<Type>
		where THandlerTypeProvider : IMessageHandlerTypeContainable, new()
	{
		public GameSceneType GameSceneTypeSearchingFor { get; }

		/// <inheritdoc />
		public AssemblyHandlerIterator(GameSceneType gameSceneTypeSearchingFor)
		{
			if(!Enum.IsDefined(typeof(GameSceneType), gameSceneTypeSearchingFor)) throw new InvalidEnumArgumentException(nameof(gameSceneTypeSearchingFor), (int)gameSceneTypeSearchingFor, typeof(GameSceneType));

			GameSceneTypeSearchingFor = gameSceneTypeSearchingFor;
		}

		/// <inheritdoc />
		public IEnumerator<Type> GetEnumerator()
		{
			THandlerTypeProvider provider = new THandlerTypeProvider();

			//Now, we have to iterate the handler Types from the container
			foreach(Type handlerType in provider.AssemblyDefinedHandlerTyped)
			{
				//TODO: Improve efficiency of all this reflection we are doing.
				IEnumerable<SceneTypeCreateAttribute> attributes = handlerType.GetCustomAttributes<SceneTypeCreateAttribute>(false);

				//We just skip now instead. For ease, maybe revert
				if(attributes == null || !attributes.Any())  //don't use base attributes
					continue;

				//if(!handlerType.HasAttribute<NetworkMessageHandlerAttribute>())
				//	throw new InvalidOperationException($"Found Handler: {handlerType.Name} with missing/no {nameof(NetworkMessageHandlerAttribute)}. All handlers must have.");

				bool isForSceneType = DetermineIfHandlerIsForSceneType(handlerType, GameSceneTypeSearchingFor);

				if(isForSceneType)
					yield return handlerType;
				else
					continue;
			}

			yield break;
		}

		/// <inheritdoc />
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		private static bool DetermineIfHandlerIsForSceneType(Type handlerType, GameSceneType sceneType)
		{
			//We don't want to get base attributes
			//devs may want to inherit from a handler and change some stuff. But not register it as a handler
			//for the same stuff obviously.
			foreach(SceneTypeCreateAttribute attris in handlerType.GetCustomAttributes<SceneTypeCreateAttribute>(false))
			{
				if(attris.SceneType == sceneType)
					return true;
			}

			return false;
		}
	}
}
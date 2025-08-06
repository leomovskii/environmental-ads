using System;
using System.Collections.Generic;
using UnityEngine;

namespace EnvironmentalAds {
	public static class EAdsController {

		#region Placements

		private readonly static HashSet<EAdsPlacement> _placements = new();

		public static void Subscribe(EAdsPlacement p) {
			_placements.Add(p);
		}

		public static void Unsubscribe(EAdsPlacement p) {
			_placements.Remove(p);
		}

		#endregion

		public static bool Initialized { get; private set; }

		public static void Initialize(Action onSuccess = null, Action<string> onFail = null) {

		}

		public static void AdClick(EAdsPlacement eAdsPlacement) {

		}
	}
}
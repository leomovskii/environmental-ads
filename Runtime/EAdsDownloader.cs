using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace EnvironmentalAds {
	public class EAdsDownloader : MonoBehaviour {
		public IEnumerator DownloadCSVDict(string url, Action<Dictionary<string, string>> onSuccess, Action<string> onFail = null) {
			if (onSuccess != null) {
				using var request = UnityWebRequest.Get(url);
				yield return request.SendWebRequest();

				if (request.result != UnityWebRequest.Result.Success) {
					onFail?.Invoke(request.error);
					yield break;
				}

				var text = request.downloadHandler.text;
				var dict = new Dictionary<string, string>();
				var lines = text.Split('\n');

				foreach (var line in lines) {
					if (string.IsNullOrWhiteSpace(line))
						continue;

					var parts = line.Split(',');
					if (parts.Length < 2)
						continue;

					string key = parts[0].Trim();
					string value = parts[1].Trim();

					dict[key] = value;
				}
				onSuccess(dict);
			}
		}
	}
}
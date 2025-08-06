using UnityEngine;

namespace EnvironmentalAds {
	public class EAdsConfig : ScriptableObject {

		#region Singleton behaviour

		private readonly static string Path = "Assets/Resources/EAdsConfig.asset";

		private static EAdsConfig _instance;

		public static EAdsConfig Instance {
			get {
				if (_instance == null) {
					_instance = Resources.Load<EAdsConfig>(Path);

					if (_instance == null) {
						_instance = CreateInstance<EAdsConfig>();

#if UNITY_EDITOR
						UnityEditor.AssetDatabase.CreateAsset(_instance, Path);
						UnityEditor.AssetDatabase.SaveAssets();

						Debug.LogWarning($"Asset {Path} don't exists. Created default instance.");

#else
						Debug.LogWarning($"Asset {Path} don't exists.");
#endif
					}
				}
				return _instance;
			}
		}

		#endregion

		[SerializeField] private string _configId;

		public string ConfigId => _configId;

	}
}
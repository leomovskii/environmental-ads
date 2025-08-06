using UnityEngine;
using UnityEngine.UI;

namespace EnvironmentalAds {
	public class EAdsPlacement : MonoBehaviour {

		[SerializeField] private RectTransform _maskRect;
		[SerializeField] private Image _image;
		[SerializeField] private AspectRatioFitter _fitter;

		public string AdId { get; private set; }

		public Vector2 Size => _maskRect.sizeDelta;

		private void OnEnable() {
			EAdsController.Subscribe(this);
		}

		private void OnDisable() {
			EAdsController.Unsubscribe(this);
		}

		public void Setup(string adId, Sprite sprite, AspectRatioFitter.AspectMode aspectMode, float aspectRatio) {
			AdId = adId;
			_fitter.aspectMode = aspectMode;
			_fitter.aspectRatio = aspectRatio;
			_image.sprite = sprite;
		}

		private void OnMouseDown() {
			EAdsController.AdClick(this);
		}
	}
}
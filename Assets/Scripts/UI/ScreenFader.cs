using System.Collections;
using UnityEngine;
using Utilities;

namespace UI
{
	public class ScreenFader : MonoBehaviour
	{
		[SerializeField] private FadeChannel _fadeChannel;
		
		[SerializeField] private CanvasGroup _faderCanvasGroup;
		
		private void OnEnable()
		{
			_fadeChannel.onEventRaised += InitiateFade;
		}

		private void OnDisable()
		{
			_fadeChannel.onEventRaised -= InitiateFade;
		}

		private IEnumerator Fade(float finalAlpha, float fadeDuration)
		{
			_faderCanvasGroup.blocksRaycasts = true;
			float fadeSpeed = Mathf.Abs(_faderCanvasGroup.alpha - finalAlpha) / fadeDuration;
			while (!MathCalculation.ApproximatelyEqualFloat(_faderCanvasGroup.alpha, finalAlpha, .05f))
			{
				_faderCanvasGroup.alpha = Mathf.MoveTowards(_faderCanvasGroup.alpha, finalAlpha,
					fadeSpeed * Time.unscaledDeltaTime);
				yield return null;
			}
			_faderCanvasGroup.alpha = finalAlpha;
			_faderCanvasGroup.blocksRaycasts = false;

			yield return null;
		}

		public void SetAlpha(float alpha)
		{
			_faderCanvasGroup.alpha = alpha;
		}
		
		private void InitiateFade(bool fadeIn, float duration)
		{
			StartCoroutine(Fade(fadeIn? 0 : 1, duration));
		}
	}
}
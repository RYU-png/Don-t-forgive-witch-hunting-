using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
	IFade fade;

	[Header("フェードイン後の待機時間")]
	[SerializeField] private float waitingTime = 0.5f;

	float cutoutRange;

	// 実行時にフェードを入れる為の準備をする関数
	public void SetFade()
    {
		fade = GetComponent<IFade>();
		cutoutRange = 1.0f;
		fade.Range = cutoutRange;
	}

	private void Init ()
	{
		fade = GetComponent<IFade>();
		fade.Range = cutoutRange;
	}

	void OnValidate ()
	{
		Init ();
		fade.Range = cutoutRange;
	}

	IEnumerator FadeoutCoroutine (float time, System.Action action)
	{
		float endTime = Time.time + time * (cutoutRange);

		var endFrame = new WaitForEndOfFrame ();

		while (Time.time <= endTime) {
			cutoutRange = (endTime - Time.time) / time;
			fade.Range = cutoutRange;
			yield return endFrame;
		}
		cutoutRange = 0;
		fade.Range = cutoutRange;

		if (action != null) {
			action ();
		}
	}

	IEnumerator FadeinCoroutine (float time, System.Action action)
	{
		float endTime = Time.timeSinceLevelLoad + time * (1 - cutoutRange);

		var endFrame = new WaitForEndOfFrame ();

		while (Time.timeSinceLevelLoad <= endTime) {
			cutoutRange = 1 - ((endTime - Time.timeSinceLevelLoad) / time);
			fade.Range = cutoutRange;
			yield return endFrame;
		}

		yield return new WaitForSeconds(waitingTime);

		cutoutRange = 1;
		fade.Range = cutoutRange;

		if (action != null) {
			action ();
		}
	}

	public Coroutine FadeOut (float time, System.Action action)
	{
		StopAllCoroutines ();
		return StartCoroutine (FadeoutCoroutine (time, action));
	}

	public Coroutine FadeOut (float time)
	{
		return FadeOut (time, null);
	}

	public Coroutine FadeIn (float time, System.Action action)
	{
		StopAllCoroutines();
		return StartCoroutine (FadeinCoroutine (time, action));
	}

	public Coroutine FadeIn (float time)
	{
		return FadeIn (time, null);
	}
}
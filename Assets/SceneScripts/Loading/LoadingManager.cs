using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingManager : SingletonMonoBehaviour<LoadingManager>
{
	//　非同期動作で使用するAsyncOperation
	private AsyncOperation async;

	//　シーンロード中に表示するUI画面
	[SerializeField]
	private GameObject loadUI;

	//　読み込み率を表示するスライダー
	[SerializeField]
	private Slider slider;

    private void Start()
    {
        
    }

	public Coroutine StartLoading(string name, System.Action action = null)
	{
		StopAllCoroutines();
		return StartCoroutine(LoadingCoroutine(name, action));
	}

	IEnumerator LoadingCoroutine(string name, System.Action action)
	{
		//　ロード画面UIをアクティブにする
		loadUI.SetActive(true);

		// シーンの読み込みをする
		async = SceneManager.LoadSceneAsync(name);

		//　読み込みが終わるまで進捗状況をスライダーの値に反映させる
		while (!async.isDone)
		{
			var progressVal = Mathf.Clamp01(async.progress / 0.9f);
			slider.value = progressVal;
			yield return null;
		}

		// ロード画面で少し待機する？？
		//async.allowSceneActivation = false;
		//yield return new WaitForSeconds(1);
		//async.allowSceneActivation = true;

		//　ロード画面UIを非アクティブにする
		loadUI.SetActive(false);

		if (action != null)
		{
			action();
		}
	}
}
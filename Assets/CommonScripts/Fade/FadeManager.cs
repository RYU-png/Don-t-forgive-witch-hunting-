using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum eMaskID // 2枚以上マスクを使用する場合、定義
{
    NONE = -1,

    MASK_1,
}
public enum eOverID // 2枚以上オーバーを使用する場合、定義
{
    NONE = -1,

    OVER_1,
}
public class FadeManager : SingletonMonoBehaviour<FadeManager>
{
    [Header("フェードを操作するスクリプト")]
    [SerializeField] private Fade fade;
    [SerializeField] private FadeImage fadeImage;

    [Header("初期のマスク・オーバー画像")]

    [Tooltip("最初のトランジションに使用するルール画像")]
    [SerializeField] private Texture defaultMask;

    [Tooltip("最初のトランジションの上に貼る画像")]
    [SerializeField] private Texture defaultOver;

    [Header("2枚以上画像が必要な場合に使用するリスト")]

    [Tooltip("トランジションに使用するルール画像")]
    [SerializeField] private List<Texture> maskList = new List<Texture>();

    [Tooltip("トランジションの上に貼る画像")]
    [SerializeField] private List<Texture> overList = new List<Texture>();

    [Header("画像ではなく色で塗りつぶす場合に使用する色")]
    [SerializeField] private Color overColor;

    [Header("実行時(ゲーム開始時)にトランジションを入れる")]
    [SerializeField] private bool start;

    [Header("フェードにかける時間(デフォルト)")]
    [SerializeField] private float defaultFadeTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        // シーンのロードで削除されないようにする
        DontDestroyOnLoad(this.gameObject);

        // 開始時のトランジション
        if (start)
        {
            // 実行時(ゲーム開始時)にトランジションを入れる為の準備関数
            fade.SetFade();

            // フェードアウト
            FadeOut();
        }
    }

    // エディタ内で変更を加えた時に呼び出される関数
    private void OnValidate()
    {
        // デフォルトマスクを設定
        fadeImage.SetMask(defaultMask);

        // デフォルトオーバーを設定
        if (defaultOver != null)
        {
            fadeImage.SetOver(defaultOver);
        }
        // defaultOverがnullの場合のみ、overColorで塗りつぶす
        else
        {
            fadeImage.SetOver(overColor);
        }
    }

    // トランジションに使用する画像を設定する関数
    public void SetMask(eMaskID id)
    {
        if (id == eMaskID.NONE) return;

        fadeImage.SetMask(maskList[(int)id]);
    }
    public void SetMask()
    {
        fadeImage.SetMask(defaultMask);
    }

    // トランジションの上に貼る画像を設定する関数
    public void SetOver(eOverID id)
    {
        if (id == eOverID.NONE) return;

        fadeImage.SetOver(overList[(int)id]);
    }
    public void SetOver()
    {
        fadeImage.SetOver(defaultOver);
    }

    // トランジションの上を塗りつぶす色を設定する関数
    public void SetOver(Color color)
    {
        fadeImage.SetOver(color);
    }

    // フェードインを行う関数(time : フェードにかける時間)
    public void FadeIn(float time, System.Action action = null)
    {
        if (action != null)
        {
            fade.FadeIn(time, action);
        }
        else
        {
            fade.FadeIn(time);
        }
    }
    public void FadeIn(System.Action action = null)
    {
        if (action != null)
        {
            fade.FadeIn(defaultFadeTime, action);
        }
        else
        {
            fade.FadeIn(defaultFadeTime);
        }
    }

    // フェードアウトを行う関数(time : フェードにかける時間)
    public void FadeOut(float time, System.Action action = null)
    {
        if (action != null)
        {
            fade.FadeOut(time, action);
        }
        else
        {
            fade.FadeOut(time);
        }
    }
    public void FadeOut(System.Action action = null)
    {
        if (action != null)
        {
            fade.FadeOut(defaultFadeTime, action);
        }
        else
        {
            fade.FadeOut(defaultFadeTime);
        }
    }

    // フェードを行いながら、シーン変更を行う関数
    public void LoadScene(float time, string name, System.Action action = null)
    {
        fade.FadeIn(time, () =>
        {
            // 実行可能な関数がある場合実行
            if (action != null)
            {
                action();
            }

            // シーン遷移
            SceneManager.LoadScene(name);

            // フェードアウト
            fade.FadeOut(time);
        });
    }
    public void LoadScene(string name, System.Action action = null)
    {
        fade.FadeIn(defaultFadeTime, () =>
        {
            // 実行可能な関数がある場合実行
            if (action != null)
            {
                action();
            }

            // シーン遷移
            SceneManager.LoadScene(name);

            // フェードアウト
            fade.FadeOut(defaultFadeTime);
        });
    }

    // フェードを行いながら、シーン追加を行う関数
    public void AddScene(float time, string name, System.Action action = null)
    {
        fade.FadeIn(time, () =>
        {
            // 実行可能な関数がある場合実行
            if (action != null)
            {
                action();
            }

            // シーン追加
            SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);

            // フェードアウト
            fade.FadeOut(time);
        });
    }
    public void AddScene(string name, System.Action action = null)
    {
        fade.FadeIn(defaultFadeTime, () =>
        {
            // 実行可能な関数がある場合実行
            if (action != null)
            {
                action();
            }

            //// シーン追加
            SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);

            // フェードアウト
            fade.FadeOut(defaultFadeTime);
        });
    }

    // フェードを行いながら、シーン削除を行う関数
    public void DeleteScene(float time, string name, System.Action action = null)
    {
        fade.FadeIn(time, () =>
        {
            // 実行可能な関数がある場合実行
            if (action != null)
            {
                action();
            }

            // シーン削除
            SceneManager.UnloadSceneAsync(name);

            // フェードアウト
            fade.FadeOut(time);
        });
    }
    public void DeleteScene(string name, System.Action action = null)
    {
        fade.FadeIn(defaultFadeTime, () =>
        {
            // 実行可能な関数がある場合実行
            if (action != null)
            {
                action();
            }

            // シーン削除
            SceneManager.UnloadSceneAsync(name);

            // フェードアウト
            fade.FadeOut(defaultFadeTime);
        });
    }
}
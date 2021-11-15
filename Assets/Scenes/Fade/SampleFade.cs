using UnityEngine;
using UnityEngine.SceneManagement;

/*************************************************************************

               ＊＊フェードを扱う上でのサンプルです。＊＊

    1.スペースキーを押すことでシーンA,シーンBをトランジションしながら
    行き来します。
    
    2.エンターキーを押すことでトランジションしながらシーンCの
    追加,削除を行います。

    -------------------------!! 注意点 !!-----------------------------
    シーンB,Cから実行するとFadeCanvasが存在しないため、動作しません。
    シーンAから実行してください。

    もし、実際に自分のプロジェクトに組み込む場合は、一番最初のシーンに
    FadeCanvasのPrefabを設置してください。
    ------------------------------------------------------------------

 *************************************************************************/

public class SampleFade : MonoBehaviour
{
    // シーン名
    public static readonly string sceneName1 = "SampleFadeA";
    public static readonly string sceneName2 = "SampleFadeB";
    public static readonly string sceneName3 = "SampleFadeC";

    // フェードにかける時間
    private static readonly float time = 0.5f;

    // Update is called once per frame
    void Update()
    {
        // 1  ===========================================================================================
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (SceneManager.GetActiveScene().name == sceneName1)
            {
                // シーンBへ遷移する(フェードにかける時間を指定しないと、デフォルトの値になる)
                FadeManager.Instance.LoadScene(sceneName2);
            }
            else if (SceneManager.GetActiveScene().name == sceneName2)
            {
                // シーンAへ遷移する(フェードにかける時間を指定：time)
                FadeManager.Instance.LoadScene(time, sceneName1);
            }
        }
        // 1  -------------------------------------------------------------------------------------------

        // 2  ===========================================================================================
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // シーンが1つの時、シーンCを追加する
            if (SceneManager.sceneCount == 1)
            {
                // シーンCを追加
                FadeManager.Instance.AddScene(sceneName3, () =>
                 {
                 });
            }
            // シーンが2つ以上時、シーンCを削除する
            else
            {
                FadeManager.Instance.DeleteScene(sceneName3, () =>
                {
                });
            }
        }
        // 2  -------------------------------------------------------------------------------------------
    }
}
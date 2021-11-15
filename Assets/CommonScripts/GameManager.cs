using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// シーンID：定数
/// </summary>
enum eSceneID
{
    NONE = -1,
    
    TITLE,
    PLAY,

    SCENE_NUM
}

/// <summary>
/// シーン名：定数
/// </summary>
public struct SceneName
{
    public const string title = "TitleScene";
    public const string play = "PlayScene";
}


public class GameManager : SingletonMonoBehaviour<GameManager>
{
    // Start is called before the first frame update
    void Start()
    {
        // シーンのロードで削除されないようにする
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 次のシーンへ遷移する関数
    public void NextScene(string name)
    {
        // フェードイン
        FadeManager.Instance.FadeIn(() =>
        {
            // フェードイン完了後、ロード開始
            LoadingManager.Instance.StartLoading(name, () =>
             {
                 // ロード完了後、フェードアウト
                 FadeManager.Instance.FadeOut(() =>
                 {
                 });
             });
        });
    }
}
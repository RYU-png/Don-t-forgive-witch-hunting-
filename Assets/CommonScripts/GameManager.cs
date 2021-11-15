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


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

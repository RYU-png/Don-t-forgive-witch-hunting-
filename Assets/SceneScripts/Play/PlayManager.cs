using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Escでタイトルへ
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.NextScene(SceneName.title);
        }
    }
}
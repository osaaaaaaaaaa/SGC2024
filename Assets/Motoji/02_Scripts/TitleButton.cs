using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        // メインシーンへ移動
        FadeManager.Instance.LoadScene("GameScene1", 1.0f);

    }

    public void OnSelectStageButton()
    {
        // メインシーンへ移動
        FadeManager.Instance.LoadScene("StageSelect", 1.0f);

    }
}

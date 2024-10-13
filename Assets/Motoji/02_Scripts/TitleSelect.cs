using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSelect : MonoBehaviour
{
    bool Selbool;
    float fYmove;
    bool bTimeSwitch;
    int nTime;
    const float fDefaultmove = 30.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        Selbool = false;
        bTimeSwitch = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)||
            Input.GetKeyDown(KeyCode.S))
        {//上または下入力時
            Selbool = !Selbool;
            SetArrowPos();
        }
        if(Input.GetKey(KeyCode.Return))
        {//Enterキー入力時
            ChangeScene();
        }

        if(nTime > 240)
        {
            bTimeSwitch = !bTimeSwitch;
            nTime = 0;
        }
        else
        {
            nTime++;
        }


        if (bTimeSwitch)
        {
            fYmove = (fDefaultmove + ( 240 - (float)nTime) * 0.5f) * Time.deltaTime;

            transform.Translate(0.0f, -fYmove, 0.0f);
        }
        else
        {
            fYmove = (fDefaultmove + (float)nTime * 0.5f) * Time.deltaTime;

            transform.Translate(0.0f, fYmove, 0.0f);
        }
    }

    void SetArrowPos()
    {
        if (Selbool) {
            transform.Translate(130.0f, 0.0f, 0.0f);
        }
        else {
            transform.Translate(-130.0f, 0.0f, 0.0f);
        }
    }

    //Enterを押した時に選択されていたものに応じて画面選択
    void ChangeScene()
    {
        if (Selbool)
        {
            SceneManager.LoadScene("StageSelect");
        }
        else
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}

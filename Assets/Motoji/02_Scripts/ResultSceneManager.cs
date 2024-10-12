using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            Invoke("ChangeScene", 1.5f);
        }
    }

    //Change to AnyScene
    void ChangeScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
}

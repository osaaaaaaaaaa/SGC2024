using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
    Vector3[] posSet = new Vector3[5];
    int nNowSelect;
    // Start is called before the first frame update
    void Start()
    {
        posSet[0] = new Vector3 (-5.66f,1.0f,0.0f);
        posSet[1] = new Vector3(-0.17f, 1.0f, 0.0f);
        posSet[2] = new Vector3( 5.32f, 1.0f, 0.0f);
        posSet[3] = new Vector3(-3.15f, -2.5f, 0.0f);
        posSet[4] = new Vector3( 3.84f, -2.5f, 0.0f);
        nNowSelect = 0;
    }
    
    // Update is called once per frame
    void Update()
    {
        bool bPushButton = false; ;
        if(Input.GetKeyDown(KeyCode.W)||
            Input.GetKeyDown(KeyCode.S))
        {
            if(nNowSelect > 2)
            {
                nNowSelect -= 3;
            }
            else
            {
                nNowSelect += 3;
            }
            if(nNowSelect > 4)
            {
                nNowSelect = 4;
            }
            else if(nNowSelect < 0)
            {
                nNowSelect = 0;
            }
            bPushButton = true;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            nNowSelect--;

            if (nNowSelect < 0)
            {
                nNowSelect = 4;
            }

            bPushButton = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            nNowSelect++;

            if (nNowSelect > 4)
            {
                nNowSelect = 0;
            }


            bPushButton = true;
        }

        if (bPushButton)
        {
            ChangePos();
        }
        
    }
    
    void ChangePos()
    {
        transform.position = (posSet[nNowSelect]);
    }
}

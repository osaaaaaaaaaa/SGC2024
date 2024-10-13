using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Goal : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    bool isTouchPlayer;

    private void Start()
    {
        isTouchPlayer = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isTouchPlayer)
        {
            isTouchPlayer = true;
            gameManager.GameClear(new Vector3(transform.position.x, transform.position.y - 0.1f, -10f));
        }
    }
}

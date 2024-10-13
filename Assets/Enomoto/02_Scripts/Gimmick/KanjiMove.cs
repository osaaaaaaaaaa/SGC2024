using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class KanjiMove : MonoBehaviour
{
    [SerializeField] Sprite spriteRight;
    [SerializeField] Sprite spriteLeft;

    public enum STATE
    {
        Right,
        Left
    }
    [SerializeField] STATE state;
    [SerializeField] Vector2 endPoint;
    [SerializeField] float time;

    Transform playerParent;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 startPoint = transform.position;

        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(endPoint, time).SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                state = state == STATE.Right ? STATE.Left : STATE.Right;
                GetComponent<SpriteRenderer>().sprite = state == STATE.Right ? spriteRight : spriteLeft;
            }))
            .Append(transform.DOMove(startPoint, time).SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                state = state == STATE.Right ? STATE.Left : STATE.Right;
                GetComponent<SpriteRenderer>().sprite = state == STATE.Right ? spriteRight : spriteLeft;
            }));
        sequence.SetLoops(-1, LoopType.Yoyo);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerParent = collision.transform.parent;

            // プレイヤーを平行移動させる
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // プレイヤーを平行移動解除
            collision.transform.parent = playerParent;
        }
    }
}

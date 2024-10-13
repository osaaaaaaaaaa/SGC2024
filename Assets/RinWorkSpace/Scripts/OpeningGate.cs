using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningGate : MonoBehaviour
{

    [SerializeField] Sprite open;
    SpriteRenderer sprite;
    BoxCollider2D boxCollider;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        
    }
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Key"))
        {
            sprite.sprite = open;
            boxCollider.enabled = false;
            gameObject.layer = 1;
        }
	}
}


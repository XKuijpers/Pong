using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atariBrick : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider;
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("atariBall"))
        {
            _spriteRenderer.color = Color.black;
            _boxCollider.isTrigger = false;
        }
    }
}
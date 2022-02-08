using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePlatform : MonoBehaviour
{
    [SerializeField] private GameObject fakeObj;

    [SerializeField] private float timeBeforeBreak;
    private bool isPlayerOnIt = false;

    private float timeToBreak;

    private void Start()
    {
        Reset();
    }

    private void Update()
    {
        if (timeToBreak <= 0f && isPlayerOnIt)
        {
            Break();
        }
        else if (isPlayerOnIt)
        {
            timeToBreak -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.collider.GetComponent<Player>();

        if (player != null)
        {
            isPlayerOnIt = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Player player = collision.collider.GetComponent<Player>();

        if (player != null)
        {
            Reset();
        }
    }

    private void Break()
    {
        Destroy(transform.root.gameObject);
    }

    private void Reset()
    {
        isPlayerOnIt = false;
        timeToBreak = timeBeforeBreak;
    }
}

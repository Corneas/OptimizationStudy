using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float h = 0f;
    private float v = 0f;

    private float moveSpeed = 5f;

    private Vector3 movePos;

    private Coroutine moveCoroutine = null;
    private WaitForEndOfFrame waitForEndOfFrame = null;

    private void Start() 
    {
        waitForEndOfFrame = new WaitForEndOfFrame();
        moveCoroutine = StartCoroutine(Move());
    }


    // private void Update()
    // {
    //     h = Input.GetAxisRaw("Horizontal");
    //     v = Input.GetAxisRaw("Vertical");

    //     movePos = new Vector3(h, v, 0).normalized * Time.deltaTime * moveSpeed;

    //     transform.Translate(movePos);
    // }

    private IEnumerator Move()
    {
        while(true)
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");

            movePos = new Vector3(h, v, 0).normalized * Time.deltaTime * moveSpeed;

            transform.Translate(movePos);

            yield return waitForEndOfFrame;
        }
    }
}
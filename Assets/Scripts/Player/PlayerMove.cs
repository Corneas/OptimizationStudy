using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float h = 0f;
    private float v = 0f;

    private float moveSpeed = 5f;

    private Vector3 movePos;

    private void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        movePos = new Vector3(h, v, 0).normalized * Time.deltaTime * moveSpeed;

        transform.Translate(movePos);
    }
}

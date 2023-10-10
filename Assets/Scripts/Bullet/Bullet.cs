using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletMoveSpeed = 8f;

    private PlayerMove player;
    private Launcher launcher;

    private float colDis = 1f;

    private WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();

    private void Start()
    {
        player = GameManager.Instance.Player;
        launcher = GameManager.Instance.Launcher;

        StartCoroutine(ColCheck());
    }

    private void Update()
    {
        transform.Translate(Vector3.down * bulletMoveSpeed * Time.deltaTime);

        //ColCheck();
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Debug.Log("面倒");
    //        launcher.Push(this);
    //    }
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Debug.Log("面倒");
    //        launcher.Push(this);
    //    }
    //}

    //public void ColCheck()
    //{
    //    if (Vector2.Distance(transform.position, player.transform.position) < colDis)
    //    {
    //        Debug.Log("面倒");
    //        launcher.Push(this);
    //    }
    //}

    public IEnumerator ColCheck()
    {
        while (true)
        {
            if (Vector2.Distance(transform.position, player.transform.position) < colDis)
            {
                Debug.Log("面倒");
                launcher.Push(this);
            }

            yield return waitForEndOfFrame;
        }
    }
}
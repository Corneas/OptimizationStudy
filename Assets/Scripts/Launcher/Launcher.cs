using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab = null;
    private Queue<Bullet> bulletQueue = new Queue<Bullet>();

    [SerializeField]
    private int bulletAmount = 0;

    private void Awake()
    {
        for(int i = 0; i < bulletAmount; ++i)
        {
            Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity).GetComponent<Bullet>();
            Push(bullet);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && bulletQueue.Count > 0)
        {
            for(int i = 0; i < bulletAmount; ++i)
            {
                Bullet bullet = Pop();
            }
        }
    }

    public void Push(Bullet bullet)
    {
        bulletQueue.Enqueue(bullet);
        bullet.gameObject.SetActive(false);
    }

    public Bullet Pop()
    {
        Bullet bullet = bulletQueue.Dequeue();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = Quaternion.Euler(0, 0, 0);
        bullet.gameObject.SetActive(true);

        return bullet;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FpsStatus : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI fpsTMP = null;
    [SerializeField]
    private TextMeshProUGUI msTMP = null;
    [SerializeField]
    private TextMeshProUGUI avgTMP = null;
    private float fps = 0f;
    private float ms = 0f;

    private float sumFps = 0;
    private float timer = 0f;
    private int counter = 0;

    private bool isStartTimer = false;

    private WaitForSeconds waitSec = new WaitForSeconds(1f);

    private void Start()
    {
        StartCoroutine(fpsCount());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            isStartTimer = true;

        if (!isStartTimer)
            return;

        sumFps += 1f / Time.unscaledDeltaTime;
        timer += Time.deltaTime;
        counter++;

        if(timer >= 10f)
        {
            Debug.Log("ЦђБе fps : " + (sumFps / counter));
            avgTMP.text = $"Avg fps : {(sumFps / counter)}";
            counter = 0;
            isStartTimer = false;
        }
    }

    private IEnumerator fpsCount()
    {
        while (true)
        {
            yield return waitSec;

            fps = 1.0f / Time.deltaTime;
            ms = Time.deltaTime * 1000.0f;

            fpsTMP.text = ($"FPS : {fps:N1}");
            msTMP.text = ($"ms : {ms:N1}");
        }
    }
}

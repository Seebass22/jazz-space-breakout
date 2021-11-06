using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarShower : MonoBehaviour
{
    public float frequency = 6f; // how many seconds before spawning another
    public float variation = 3f; // how variation on the above spawning rate
    private float timer = 0f;
    private float nextStar = 0f;
    public GameObject prefab;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > nextStar)
        {
            SpawnShootingStar();
            timer = 0f;
            nextStar = frequency + Random.Range(-variation, variation);
        }
    }
    void SpawnShootingStar()
    {
        GameObject shootingStar = Instantiate(prefab);
        shootingStar.transform.localScale = new Vector3(Random.Range(0.4f, 1f), Random.Range(0.4f, 1f), Random.Range(0.4f, 1f));
        shootingStar.transform.localPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-5f, 5f), 0f);
        shootingStar.transform.localRotation = Quaternion.Euler(Random.Range(-50f, 50f), 0, 0);
    }
}

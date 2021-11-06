using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailSpriteBlur : MonoBehaviour
{
    public float trailAnimationSpeed = 1f;
    public float trailLifetime = 1f;
    public float trailLag = 0.5f;
    public GameObject prefab;

    private float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > trailLag)
        {
            GameObject p = Instantiate(prefab,this.transform.position, this.transform.rotation);
            p.GetComponent<Animator>().SetFloat("MotionSpeed", trailAnimationSpeed);
            StartCoroutine(TidyUpTrailGameObject(p));

            timer = 0f;
        }
    }

    IEnumerator TidyUpTrailGameObject(GameObject gameObject)
    {
        yield return new WaitForSeconds(trailLifetime);
        Destroy(gameObject);
    }
}

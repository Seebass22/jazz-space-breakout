using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedBrick : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        AddExplosionForce(Random.Range(40f, 70f), 0.2f);
    }

    public void AddExplosionForce(float explosionForce, float upwardsModifier = 0.0F, ForceMode2D mode = ForceMode2D.Force)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        var explosionDir = rb.position - new Vector2(this.transform.parent.position.x, this.transform.parent.position.y);
        var explosionDistance = explosionDir.magnitude;

        // Normalize without computing magnitude again
        if (upwardsModifier == 0)
            explosionDir /= explosionDistance;
        else
        {
            // From Rigidbody.AddExplosionForce doc:
            // If you pass a non-zero value for the upwardsModifier parameter, the direction
            // will be modified by subtracting that value from the Y component of the centre point.
            explosionDir.y += upwardsModifier;
            explosionDir.Normalize();
        }

        rb.AddForce(Mathf.Lerp(0, explosionForce, (100 - explosionDistance)) * explosionDir, mode);
    }
}


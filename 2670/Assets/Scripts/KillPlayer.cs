using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public FloatData Health;

    private void OnTriggerEnter(Collider other)
    {
        if (Health.Value <= 0)
        {
            Destroy(gameObject);
        }
    }
}

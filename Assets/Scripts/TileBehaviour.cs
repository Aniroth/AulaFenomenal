using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    void Update()
    {
        if (!GameManager.instance.isPlayerDead)
        {
            transform.position -= new Vector3(0f, 0f, 10f * Time.deltaTime);

            if (transform.position.z < -20f)
            {
                Destroy(gameObject);
            }
        }
    }
}

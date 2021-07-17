using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private float _timeToDestroy = 10.0f;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject wall = Resources.Load<GameObject>("Wall");

        GameObject wallGameObj = Instantiate(wall, Vector3.zero, Quaternion.identity, gameObject.transform);

        Destroy(wallGameObj, _timeToDestroy);
    }
}

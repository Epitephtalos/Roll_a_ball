using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{

    void Start()
    {
        Vector3 position = new Vector3(Random.Range(-49.0f, 49.0f), 1.5f, Random.Range(-49.0f, 49.0f));
        transform.position = position;
    }

    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
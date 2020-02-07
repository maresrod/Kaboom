using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBomb : MonoBehaviour
{
    public GameObject bomb;
    public ParticleSystem explosion;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider col)
    {
        Destroy(col.gameObject);
        ParticleSystem exp = Instantiate(explosion, col.gameObject.transform.position, col.gameObject.transform.rotation);
        Destroy(exp.gameObject, 1);
    }
}

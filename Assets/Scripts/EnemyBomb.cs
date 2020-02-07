using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBomb : MonoBehaviour
{
    public float Timer = 1;
    protected float temp = 1;

    public GameObject bomb = null;

    public GameObject follow = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    temp -= Time.deltaTime;
     if (temp <= 0f)
     {         
        dropBomb();
         temp = Timer;
     }
    }



    void dropBomb(){
        Vector3 position = follow.transform.position;
        position.y = 1;
        position.x = position.x + 0.5f;
        Instantiate(bomb, position, Quaternion.identity);
    }
}

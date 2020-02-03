using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

    public int velocidad = 2;
    public int velocidad2 = 2;
    private Renderer platformRenderer;
    private float platformHalfWidth;

    private float platformRightBound;

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("Screen width: " + Screen.width + "Screen height: " + Screen.height);
        platformRenderer = GetComponent<Renderer>();
        platformHalfWidth = platformRenderer.bounds.center.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        movementByKey();
        Debug.Log("Magnitu:=" + platformHalfWidth);
    }

    void movementByKey()
    {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(vKey))
            {
                Vector3 position = this.transform.position;
               

                //Debug.Log("Tecla=" + vKey.ToString());

                Vector3 tmpPos = Camera.main.WorldToScreenPoint(transform.position);

                switch (vKey.ToString())
                {
                    case "RightArrow":
                        if (!(tmpPos.x + platformHalfWidth > Screen.width * 0.99))
                        {
                            transform.Translate(velocidad * (Time.deltaTime * 8), 0, 0);
                        }
                        break;
                    case "LeftArrow":
                        if (!(tmpPos.x - platformHalfWidth < Screen.width * 0.01))
                        {
                            transform.Translate(-velocidad * (Time.deltaTime * 8), 0, 0);
                        }
                        break;
                }

            }
        }
    }

}

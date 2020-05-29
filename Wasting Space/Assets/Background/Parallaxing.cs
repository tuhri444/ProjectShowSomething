using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour
{

    public Transform[] background; //Images to be parallaxed
    private float[] Scales;

    public float smoothing = 1f; //Needs to be above 0

    public Transform cam;
    private Vector3 previousCamPos; 

  

    // Start is called before the first frame update
    void Start()
    {
        previousCamPos = cam.position;

        Scales = new float[background.Length];

        for (int i = 0; i < background.Length; i++)
        {
            Scales[i] = background[i].position.z * -1;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i< background.Length; i++ )
        {
            float parallax = (previousCamPos.x - cam.position.x) * Scales[i];
            float parallaxY = (previousCamPos.y - cam.position.y) * Scales[i];

            float backgroundTargetPosX = background[i].position.x + parallax;
            float backgroundTargetPosY = background[i].position.y + parallax;


            Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, background[i].position.y, background[i].position.z);
            Vector3 backgroundTargetPosVer = new Vector3 (backgroundTargetPosY, background[i].position.x, background[i].position.z);

            background[i].position = Vector3.Lerp (background[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
            background[i].position = Vector3.Lerp (background[i].position, backgroundTargetPosVer, smoothing * Time.deltaTime);


        }

        previousCamPos = cam.position;
        
    }
}

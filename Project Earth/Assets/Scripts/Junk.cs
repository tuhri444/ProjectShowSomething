using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Junk : MonoBehaviour
{
    // Start is called before the first frame update
    public float scale;
    public int score;
    [SerializeField] private ChildJunk[] littleJunks;

    private void Start()
    {
        littleJunks = GetComponentsInChildren<ChildJunk>(true);
        if (littleJunks.Length > 1)
        {
            scale = Random.Range(0.5f, 1.0f);
            score = (int)(scale * 10.0f);
            transform.localScale = new Vector3(scale, scale, scale);
        }
    }


    public void Explode()
    {
        if(littleJunks.Length > 1)
        {
            for(int i = 0; i < littleJunks.Length; i++)
            {
                littleJunks[i].gameObject.SetActive(true);
                littleJunks[i].transform.parent = transform.parent;
            }
            Destroy(this);
        }
    }
}

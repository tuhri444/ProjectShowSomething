using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOff : MonoBehaviour
{
    [SerializeField] Hull player;
    public int TotalJunkDroppedOff;
    private bool isDropping;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Hull>() && player.junkCollected > 0)
        {
            if (!isDropping)
                StartCoroutine(Countdown());
            player.transform.position = transform.position;
            player.transform.right = Vector3.up;
        }
    }

    private IEnumerator Countdown()
    {
        isDropping = true;
        float duration = 0.5f;
        float normalizedTime = 0;
        while (normalizedTime <= 1.0f)
        {
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }
        if(player.junkCollected >=1 )
        {
            player.junkCollected -= 1;
            TotalJunkDroppedOff += 1;
        }
        isDropping = false;
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Device : MonoBehaviour
{
    [SerializeField] AudioClip clickSound;
    private int count;
   
   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectible")) 
        
        {
            count++;
            AudioSource.PlayClipAtPoint(clickSound, other.transform.position);
           
            Destroy(other.gameObject);
        
        
        }
    }
}

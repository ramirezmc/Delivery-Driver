using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(0, 0, 0, 1);
    [SerializeField] float timeDelay = 0.5f;
    [SerializeField] int scoreValue = 100;
    bool hasPackage;
    SpriteRenderer spriteRenderer;
    ScoringSystem scoringSystem;
    AudioPlayer audioPlayer;
    void Start() 
    {
        scoringSystem = FindObjectOfType<ScoringSystem>();
        spriteRenderer = GetComponent<SpriteRenderer>();    
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Customer" && !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            audioPlayer.PackagePickedUpSFX();
            spriteRenderer.color = hasPackageColor;
        }
        if(other.tag == "Package" && hasPackage)
        {
            Debug.Log("Package Delivered");
            audioPlayer.PackageDeliveredSFX();
            hasPackage = false;
            Destroy(other.gameObject, timeDelay);
            spriteRenderer.color = noPackageColor;
            scoringSystem.AddScore(scoreValue);
        }
    }
}

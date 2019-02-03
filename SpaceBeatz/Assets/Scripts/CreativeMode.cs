using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreativeMode : MonoBehaviour
{

    public bool creativeMode;
    public GameObject asteroid;
    public Transform rocket;
    public Transform movePointLeft;
    public Transform movePointRight;
    public Transform endLimit;
    public AudioSource mainAudioSource;
    void Start()
    {
        //if its not creative mode, free this values
        if (!creativeMode)
        {
            AudioProcessor audioProcessor = FindObjectOfType<AudioProcessor>();
            Destroy(audioProcessor);
            Destroy(this);
        }
        else
        {
            rocket.gameObject.SetActive(false);
            endLimit.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
#if UNITY_EDITOR
        if (!mainAudioSource.isPlaying && Time.timeScale!=0)
        {
            Time.timeScale = 0;
            Debug.Log("Paused"); 
        }
#endif
    }
    public void OnBeat()
    {
#if UNITY_EDITOR
        Debug.Log("Beat!");
#endif
        int randomPoint = Random.Range(0, 2);
        Vector2 spawnPoint = randomPoint == 0 ? movePointLeft.position : movePointRight.position;
        Instantiate(asteroid, spawnPoint, Quaternion.identity);
    }
}

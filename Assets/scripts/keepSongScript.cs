using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class keepSongScript : MonoBehaviour
{
    private static keepSongScript instance = null;
    private AudioSource audioSource;
    public AudioClip newClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
       
    }
    /*private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Menu" || scene.name == "End")
        {
            Destroy(audioSource);
        }

    }*/
}

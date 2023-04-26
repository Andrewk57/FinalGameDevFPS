using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class keyHandler : MonoBehaviour
{
    public string nextScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(nextScene);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

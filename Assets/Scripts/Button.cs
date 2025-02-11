using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Video;

public class Button : MonoBehaviour
{
    public VideoPlayer videoPlayer; 
    public GameObject currentcanvas;
    public GameObject VideoCanvas;
    public float delaytime = 2f;

    public void Start()
    {
        VideoCanvas.SetActive(false);
        videoPlayer = GetComponent<VideoPlayer>();
    }

    public void OnClick()
    {
        Debug.Log("Button Clicked");
        currentcanvas.SetActive(false); 
        VideoCanvas.SetActive(true);
        videoPlayer.Play();
        StartCoroutine(LoadNextScene());
    }
     IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(delaytime); 
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
 public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
     public void Options ()
     {
         Debug.Log("Options");
      
     }

}
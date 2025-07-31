using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagerSystem : MonoBehaviour
{
    [Header("Refrences")]
    public Button sceneChanger;
    public AudioSource onclickAudio; // the audio is going to play when button clicked    

    [Header("Settings")]
    public string Scene; // the scene is going to play

    private void Start()
    {
        sceneChanger.onClick.AddListener(SceneChange);
        onclickAudio = GetComponent<AudioSource>();

        // main settings
        onclickAudio.playOnAwake = false;
    }

    void SceneChange()
    {
        SceneManager.LoadScene(Scene); // loading the scene
        onclickAudio.Play();
    }
}
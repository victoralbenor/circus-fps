using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFirstScene : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
    }
}

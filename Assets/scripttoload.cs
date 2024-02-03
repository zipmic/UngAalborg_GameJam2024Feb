using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scripttoload : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}

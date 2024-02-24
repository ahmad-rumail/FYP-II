using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void Restart1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

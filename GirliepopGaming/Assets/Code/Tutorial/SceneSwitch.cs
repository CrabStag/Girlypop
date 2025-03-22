using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public string SceneFileName;


    private void OnMouseUpAsButton()
    {
        ChangeScene();
    }

    public void ChangeScene ()
    {
        SceneManager.LoadScene(SceneFileName);
    }

}

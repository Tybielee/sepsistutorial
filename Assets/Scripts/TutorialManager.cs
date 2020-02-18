using Sepsis.Xml;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Base class that will be used by all scenes for object management.
/// </summary>
public class TutorialManager : MonoBehaviour
{
    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Start function being called");
        XmlParser parser = new XmlParser();
        Debug.Log(parser.GetSceneTitle(scene.name));
        Debug.Log(parser.GetSceneContent(scene.name));
        Debug.Log($"Active Scene is {scene.name} and build index is {scene.buildIndex}.");
    }

    /// <summary>
    /// Update is called once per frame. 
    /// </summary>
    void Update()
    {
        Debug.Log("Update Function Being Called");
    }
}

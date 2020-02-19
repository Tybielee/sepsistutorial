using Sepsis.Xml;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// Base class that will be used by all scenes for object management.
/// </summary>
public class TutorialManager : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI content;
    public TextMeshProUGUI specialInstructions;
    public TextMeshProUGUI notes;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        this.InitalizeTextObjects();
        this.SetTextObjects();
    }

    /// <summary>
    /// Update is called once per frame. 
    /// </summary>
    void Update()
    {
        Debug.Log("Update Function Being Called");
    }

    /// <summary>
    /// Initializes the text property of the Text Mesh Pro objects to String.Empty
    /// </summary>
    private void InitalizeTextObjects()
    {
        title.text = String.Empty;
        content.text = String.Empty;
        specialInstructions.text = String.Empty;
        notes.text = String.Empty;
    }

    /// <summary>
    /// Sets the text properties of the Text Mesh Pro objects to the value in the XML file.
    /// </summary>
    private void SetTextObjects()
    {
        XmlParser parser = new XmlParser();
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log($"Active Scene is {scene.name} and build index is {scene.buildIndex}.");
        string titleText = parser.GetSceneTitle(scene.name);
        if (titleText != null)
        {
            title.text = titleText;
            print(titleText);
        }

        string contentText = parser.GetSceneContent(scene.name);
        if (contentText != null)
        {
            content.text = contentText;
            print(contentText);
        }

        string specialInstructText = parser.GetSceneInstructions(scene.name);
        if (specialInstructText != null)
        {
            specialInstructions.text = specialInstructText;
            print(specialInstructText);
        }
        
        string notesText = parser.GetSceneNotes(scene.name);
        if (notesText != null)
        {
            notes.text = notesText;
            print(notesText);
        }
    }
}

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
    /// <summary>
    /// Property to access to the Text Mesh Pro Guid text item for the content.
    /// </summary>
    public TextMeshProUGUI content;

    /// <summary>
    /// Property to access to the Text Mesh Pro Guid text item for the notes.
    /// </summary>
    public TextMeshProUGUI notes;

    /// <summary>
    /// Property to access to the Text Mesh Pro Guid text item for the special instructions.
    /// </summary>
    public TextMeshProUGUI specialInstructions;

    /// <summary>
    /// Property to access to the Text Mesh Pro Guid text item for the title.
    /// </summary>
    public TextMeshProUGUI title;

    /// <summary>
    /// Private variable holding the name of the scene that is after the current scene.
    /// </summary>
    private string nextSceneName;

    /// <summary>
    /// Private variable that allows the current file to utilize xml parsing.
    /// </summary>
    private XmlParser parser;

    /// <summary>
    /// Variable that holds the current scene.
    /// </summary>
    private Scene scene;

    /// <summary>
    /// Initializes the text property of the Text Mesh Pro objects to String.Empty
    /// </summary>
    private void InitalizeTextObjects()
    {
        this.title.text = String.Empty;
        this.content.text = String.Empty;
        this.specialInstructions.text = String.Empty;
        this.notes.text = String.Empty;
    }

    /// <summary>
    /// A coroutine that will display the text on screen and send the user to the next scene.
    /// </summary>
    /// <returns>an Ienumerator for use in the coroutine stack.</returns>
    private IEnumerator NextSceneLogic(){
        
        yield return new WaitForSeconds(4);

        if (!this.content.enabled)
        {
            this.content.enabled = true;
            yield return new WaitForSeconds(10);
        }

        if (!this.specialInstructions.enabled)
        {
            this.specialInstructions.enabled = true;
            yield return new WaitForSeconds(5);
        }

        if (!this.notes.enabled)
        {
            this.notes.enabled = true;
            yield return new WaitForSeconds(7);
        }

        if (!String.IsNullOrEmpty(this.nextSceneName))
        {
            SceneManager.LoadScene(this.nextSceneName);
        }
    }

    /// <summary>
    /// Sets the text properties of the Text Mesh Pro objects to the value in the XML file.
    /// </summary>
    private void SetTextObjects()
    {
        string titleText = this.parser.GetSceneTitle(scene.name);
        if (titleText != null)
        {
            this.title.text = titleText;
        }

        string contentText = this.parser.GetSceneContent(scene.name);
        if (contentText != null)
        {
            this.content.text = contentText;
            this.content.enabled = false;
        }

        string specialInstructText = this.parser.GetSceneInstructions(scene.name);
        if (specialInstructText != null)
        {
            this.specialInstructions.text = specialInstructText;
            this.specialInstructions.enabled = false;
        }
        
        string notesText = this.parser.GetSceneNotes(scene.name);
        if (notesText != null)
        {
            this.notes.text = notesText;
            this.notes.enabled = false;
        }
    }

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        this.parser = new XmlParser();
        this.scene = SceneManager.GetActiveScene();
        this.InitalizeTextObjects();
        this.SetTextObjects();
        this.nextSceneName = this.parser.GetNextSceneName(this.scene.name);
        StartCoroutine("NextSceneLogic");
    }

    /// <summary>
    /// Updates is called once per frame.
    /// Currently will close the applications if the escape key is pressed.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Application.Quit();
        }
    }
}

using Sepsis.Xml;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to build and run unit tests to verifying the xml parsing is correct.
///</summary>
public class XmlParserTests : MonoBehaviour
{
    /// <summary>
    /// Start is called before the first frame update. 
    /// Currently used to display logs to the console with tests passing.
    /// </summary>
    void Start()
    {
        string airwayScene = "AirwayScene";
        bool airwayTitlePassed = this.VerifySceneTitle(airwayScene, "Airway");
        this.LogTestResults(airwayScene, "title verification", airwayTitlePassed);
        string airwayContent = "Assess and maintain patient airway";
        bool airwayContentPassed = this.VerifySceneContent(airwayScene, airwayContent);
        this.LogTestResults(airwayScene, "content verification", airwayContentPassed);
    }

    /// <summary>
    /// Verifies the content string obtained from the xml file is correct.
    /// </summary>
    /// <param name="sceneName">The scene name for which to obtain the title text.</param>
    /// <param name="expectedContent">The expeected title for the scene.</param>
    /// <returns>True if the content matches; false otherwise.</returns>
    private bool VerifySceneContent(string sceneName, string expectedContent)
    {
        XmlParser parser = new XmlParser();
        string sceneContent = parser.GetSceneContent(sceneName);
        return sceneContent == expectedContent;
    }

    /// <summary>
    /// Verifies the title string obtained from the xml file is correct.
    /// </summary>
    /// <param name="sceneName">The scene name for which to obtain the title text.</param>
    /// <param name="expectedTitle">The expeected title for the scene.</param>
    /// <returns>True if the title matches; false otherwise.</returns>
    private bool VerifySceneTitle(string sceneName, string expectedTitle)
    {
        XmlParser parser = new XmlParser();
        string sceneTitle = parser.GetSceneTitle(sceneName);
        return sceneTitle == expectedTitle;
    }

    /// <summary>
    /// Logs to the console the results of a test.
    /// </summary>
    /// <param name="sceneName">The scene name for which to obtain the title text.</param>
    /// <param name="testType">What type of verification occurred; title or content</param>
    /// <param name="result">The result of the verification test.</param>
    private void LogTestResults(string sceneName, string testType, bool result)
    {
        Debug.Log($"{sceneName} - Type {testType} Passing: {result}");
    }
}

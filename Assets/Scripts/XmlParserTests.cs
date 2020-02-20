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
        bool airwayNextScenePassed = this.VerifyNextSceneCorrect(airwayScene, "BreathingScene");
        this.LogTestResults(airwayScene, "next scene verification", airwayNextScenePassed);

        string circulationInvest = "CirculationInvestigationScene";
        string expectedCirculationNotes = "Document all investigation and cultures collected in file.";
        bool investigationNotesPassed = this.VerifySceneNotes(circulationInvest, expectedCirculationNotes);
        this.LogTestResults(circulationInvest, "notes verification", investigationNotesPassed);

        string circulationFluid = "CirculationFluidScene";
        string expectedFluidSpecialInstructions = "Consider commencement of vasopressors.";
        bool specialInstructionsPassed = this.VerifySceneSpecialInstructions(circulationFluid, expectedFluidSpecialInstructions);
        this.LogTestResults(circulationFluid, "special instructions verification", specialInstructionsPassed);
    }

    /// <summary>
    /// Verifies the next scene name string obtained from the xml file is correct.
    /// </summary>
    /// <param name="currentSceneName">The scene name for which to obtain the next scene name text.</param>
    /// <param name="expectedSceneName">The expected scene name for the current scene.</param>
    /// <returns>True if the name matches; false otherwise.</returns>
    private bool VerifyNextSceneCorrect(string currentSceneName, string expectedSceneName) 
    {
        XmlParser parser = new XmlParser();
        string nextSceneName = parser.GetNextSceneName(currentSceneName);
        return nextSceneName == expectedSceneName;
    }

    /// <summary>
    /// Verifies the content string obtained from the xml file is correct.
    /// </summary>
    /// <param name="sceneName">The scene name for which to obtain the content text.</param>
    /// <param name="expectedContent">The expected content for the scene.</param>
    /// <returns>True if the content matches; false otherwise.</returns>
    private bool VerifySceneContent(string sceneName, string expectedContent)
    {
        XmlParser parser = new XmlParser();
        string sceneContent = parser.GetSceneContent(sceneName);
        return sceneContent == expectedContent;
    }

    /// <summary>
    /// Verifies the notes string obtained from the xml file is correct.
    /// </summary>
    /// <param name="sceneName">The scene name for which to obtain the notes text.</param>
    /// <param name="expectedNotes">The expected notes for the scene.</param>
    /// <returns>True if the notes matches; false otherwise.</returns>
    private bool VerifySceneNotes(string sceneName, string expectedNotes)
    {
        XmlParser parser = new XmlParser();
        string sceneContent = parser.GetSceneNotes(sceneName);
        return sceneContent == expectedNotes;
    }

    /// <summary>
    /// Verifies the spceial instructions string obtained from the xml file is correct.
    /// </summary>
    /// <param name="sceneName">The scene name for which to obtain the special instructions text.</param>
    /// <param name="expectedContent">The expected special instructions for the scene.</param>
    /// <returns>True if the special instructions matches; false otherwise.</returns>
    private bool VerifySceneSpecialInstructions(string sceneName, string expectedInstructions)
    {
        XmlParser parser = new XmlParser();
        string sceneInstructions = parser.GetSceneInstructions(sceneName);
        return sceneInstructions == expectedInstructions;
    }

    /// <summary>
    /// Verifies the title string obtained from the xml file is correct.
    /// </summary>
    /// <param name="sceneName">The scene name for which to obtain the title text.</param>
    /// <param name="expectedTitle">The expected title for the scene.</param>
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

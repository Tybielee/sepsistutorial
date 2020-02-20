using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

namespace Sepsis.Xml {

    /// <summary>
    /// Public class that will parse the sepsis xml file.
    /// </summary>
    public class XmlParser
    {

        /// <summary>
        /// Stores the path to the xml file containing the strings for the sepsis tutorial.
        /// Currently commented out because we are loading the xml as a text asset instead.
        /// </summary>
        // private string filePath = Application.absoluteURL+"Assets/Resources/sepsis.xml";

        /// <summary>
        /// stores the xml file as an XElement.
        /// </summary>
        private XElement scenes;

        /// <summary>
        /// Constructor
        /// </summary>
        public XmlParser()
        {
            // If you don't want to have to recompile the bulid everything you make an xml change.
            // Note when you build you will need to copy the Path Assets/Resources/{file} into the create folder, as the resources were not copied over.
            // this.scenes = XElement.Load(this.filePath);
            TextAsset xmlAsset = Resources.Load("sepsis") as TextAsset;
            this.scenes = XElement.Parse(xmlAsset?.text ?? "");
        }

        /// <summary>
        /// Obtains the scene name that is after the current scene.
        ///</summary>
        /// <param name="currentSceneName">The current scene name.</param>
        /// <returns>A string containing the name of the next scene.</returns>
        public string GetNextSceneName(string currentSceneName)
        {
            return this.FindNextScene(currentSceneName);
        }

        /// <summary>
        /// Gets the content text for the specified scene.
        /// </summary>
        /// <param name="sceneName">The scene name for which to obtain the content text.</param>
        /// <returns>A string containing the content for the scene.</returns>
        public string GetSceneContent(string sceneName)
        {
            return (string)this.FindNodeBySceneNameAndElement(sceneName, "content").FirstOrDefault();
        }

        /// <summary>
        /// Gets the special instructions text for the specified scene.
        /// </summary>
        /// <param name="sceneName">The scene name for which to obtain the special instructions text.</param>
        /// <returns>A string containing the special instructions for the scene.</returns>
        public string GetSceneInstructions(string sceneName) 
        {
            return (string)this.FindNodeBySceneNameAndElement(sceneName, "specialInstructions").FirstOrDefault();
        }

        /// <summary>
        /// Gets the notes text for the specified scene.
        /// </summary>
        /// <param name="sceneName">The scene name for which to obtain the notes text.</param>
        /// <returns>A string containing the notes for the scene.</returns>
        public string GetSceneNotes(string sceneName) 
        {
            return (string)this.FindNodeBySceneNameAndElement(sceneName, "notes").FirstOrDefault();
        }

        /// <summary>
        /// Gets the title text for the specified scene.
        /// </summary>
        /// <param name="sceneName">The scene name for which to obtain the title text.</param>
        /// <returns>A string containing the title for the scene.</returns>
        public string GetSceneTitle(string sceneName) 
        {
            return (string)this.FindNodeBySceneNameAndElement(sceneName, "title").FirstOrDefault();
        }

        /// <summary>
        /// Obtains the scene name that is after the current scene.
        ///</summary>
        /// <param name="currentSceneName">The current scene name.</param>
        /// <returns>A string containing the name of the next scene.</returns>
        private string FindNextScene(string currentSceneName)
        {
            XElement currentScene = scenes.Descendants("scene").Where(scene => (string)scene.Attribute("id") == currentSceneName).FirstOrDefault();
            
            XNode nextNode = currentScene?.NextNode;
            if (nextNode != null) 
            {
                return XElement.Parse(nextNode.ToString())?.Attribute("id")?.Value;
            }
            else 
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// Gets the correct XElement based on the scene name and element name.
        /// </summary>
        /// <param name="sceneName">The scene name for which to obtain the XElement.</param>
        /// <returns>A IEnumerable of XElements</returns>
        private IEnumerable<XElement> FindNodeBySceneNameAndElement(string sceneName, string elementName)
        {
            return scenes.Descendants("scene").Where(scene => (string)scene.Attribute("id") == sceneName)
                                            .Select(scene => scene.Element(elementName));
        }
    }
}



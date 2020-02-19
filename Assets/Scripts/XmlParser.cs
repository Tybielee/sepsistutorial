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
        // Stores the path to the xml file containing the strings for the sepsis tutorial.
        private string filePath = Application.absoluteURL+"Assets/Resources/sepsis.xml";

        /// <summary>
        /// Gets the content text for the specified scene.
        /// </summary>
        /// <param name="sceneName">The scene name for which to obtain the content text.</param>
        /// <returns>A string containing the content for the scene.</returns>
        public string GetSceneContent(string sceneName)
        {
            return (string)this.FindNode(sceneName, "content").FirstOrDefault();
        }

        /// <summary>
        /// Gets the special instructions text for the specified scene.
        /// </summary>
        /// <param name="sceneName">The scene name for which to obtain the special instructions text.</param>
        /// <returns>A string containing the special instructions for the scene.</returns>
        public string GetSceneInstructions(string sceneName) 
        {
            return (string)this.FindNode(sceneName, "specialInstructions").FirstOrDefault();
        }

        /// <summary>
        /// Gets the notes text for the specified scene.
        /// </summary>
        /// <param name="sceneName">The scene name for which to obtain the notes text.</param>
        /// <returns>A string containing the notes for the scene.</returns>
        public string GetSceneNotes(string sceneName) 
        {
            return (string)this.FindNode(sceneName, "notes").FirstOrDefault();
        }

        /// <summary>
        /// Gets the title text for the specified scene.
        /// </summary>
        /// <param name="sceneName">The scene name for which to obtain the title text.</param>
        /// <returns>A string containing the title for the scene.</returns>
        public string GetSceneTitle(string sceneName) 
        {
            return (string)this.FindNode(sceneName, "title").FirstOrDefault();
        }

        /// <summary>
        /// Gets the correct XElement based on the scene name and element name.
        /// </summary>
        /// <param name="sceneName">The scene name for which to obtain the XElement.</param>
        /// <returns>A IEnumerable of XElements</returns>
        private IEnumerable<XElement> FindNode(string sceneName, string elementName)
        {
            XElement scenes = XElement.Load(filePath);
            return scenes.Descendants("scene").Where(scene => (string)scene.Attribute("id") == sceneName)
                                            .Select(scene => scene.Element(elementName));
        }
    }
}



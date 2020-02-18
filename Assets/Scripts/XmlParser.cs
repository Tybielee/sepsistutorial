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
        /// Gets the title text for the specified scene.
        /// </summary>
        /// <param name="sceneName">The scene name for which to obtain the title text.</param>
        /// <returns>A string containing the title for the scene.</returns>
        public string GetSceneTitle(string sceneName) 
        {
            return (string)this.FindNode(sceneName, "title").FirstOrDefault();
        }

        /// <summary>
        /// Gets the content text for the specified scene.
        /// </summary>
        /// <param name="sceneName">The scene name for which to obtain the content text.</param>
        /// <returns>A string containing the content for the scene.</returns>
        private IEnumerable<XElement> FindNode(string sceneName, string elementName)
        {
            XElement scenes = XElement.Load(filePath);
            return scenes.Descendants("scene").Where(scene => (string)scene.Attribute("id") == sceneName)
                                            .Select(scene => scene.Element(elementName));
        }
    }
}



# sepsistutorial
The sepsis tutorial project contains a planning document that outlines the specific features and timeline for creating this tutorial, if it were to be used outside the purposes of this exercise. The code example will be built in Unity 2019.2.17f1 Personal

## General Information About The Code
**XmlParser.cs** - This contains the code that reads from the XML file or the TextAsset holding XML content. It utilizes LINQ to XML for the functionality and allows the user to obtain the following.
  * The next scene
  * The current scene's title, content, special instructions and notes.
  
**XMLParserTests.cs** - This contains basic unit tests to verify that the XML parsing is working as expected.

**TutorialManager.cs** - This is the "brains" of the tutorial and contains all logic for what is scene in the final build.
  * Utilizes a Coroutine to show/hide text and load the next scene.
  * Initalizes all TextMeshProUGUI items to String.Empty and disables them if there is no content.
  * Contains the escape key logic for exiting the application at any point.

## Final Build
An example of the work done that was outlined in Appendix C of the planning document can be found in the Final Build folder.

### Running the Final Build
The build created targeted Windows, so you should be attempting to run this on a Windows PC.
* Clone the sepsistutorial repositiory to your local machine. Alternatively you can download the zip file from Github.com as well
* Open the repository folder in your Windows Explorer and navigate to FinalBuild or unzip the document downloaded and navigate to the FinalBuild folder.
* Find the `SepsisTutorial.exe` and open it. 
  Some ways to open the file include:
    * Double clicking the file, 
    * Right-clicking the file and selecting open from the drop-down, 
    * Right-clicking and selecting run as admin, or 
    * Pressing Windows key + R to open the run box where you can input the path to the executable file and press Ok.
* You may get a warning from Windows Security Alert that it blocked some features but you do not need to allow access as the example will start to run automatically without it.
    
* The tutorial will automatically start and progress through the Airways, Breathing and Circulation Steps of the Sepsis Pathway. See Scene Logic for more information on the timing of each scene.

#### Scene Logic

  * After the title is shown, there will be a delay of 4 seconds before the next content appears.

  * After the next content appears, there will be a delay of 12 seconds before further content appears, if any.
    * If further content is not neccessary on this scene, the next scene will be loaded after the delay.

  * If there is still content, that will be shown and a delay of 7 seconds will occur. This content holds any special instructions for that particular step.
    * If further content is not neccessary on this scene, the next scene will be loaded after the delay.

  * If there is still content, that will be shown and a delay of 12 seconds will occur before the next scene/step is shown. This content holds any notes to be aware of for the particular step.

  **The delays were added to allow for reading time by the user.**




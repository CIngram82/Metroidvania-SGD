//////////////////////////////////////////////////////
// File: REUSABLE FUNCTION CALLS
// Name: Robert Secoura
// Date: 02/17/20
//////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace Extensions
{
    public static class FunctionsLibrary
    {
        /* CheckForClicks(string tag)
         * Checks for mouse click on 
         * gameObject with specified tag.
         * REUSABLE
        */
        public static void CheckForClicks(string tag)
        {
            RaycastHit hit;
            Ray selectionRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(selectionRay, out hit) && Input.GetMouseButtonDown(0))
            {
                if (hit.collider.tag == tag)
                {

                }
            }
        }
    }
    
    /* Functions for GameObjects */
    public static class GameObjectExt
    {
		/*/
		public static List<GameObject> GetChildren(GameObject parent)
		{
			List<GameObject> children = new List<GameObject>();
			
			foreach (Transform transform in parent.GetComponentsInChildren<Transform>())
			{
				if (parent != transform.gameObject)
				{
					//Debug.LogWarning(transform.gameObject);
					children.Add(transform.gameObject); 
				}
			}
			return children;
		}
		/**/
		public static List<GameObject> GetChildren(GameObject parent)
		{
			List<GameObject> children = new List<GameObject>();

			foreach (Transform child in parent.transform)
			{
				if (child.IsChildOf(parent.transform))
				{
					children.Add(child.gameObject);
				}
			}
			return children;
		}

		/* Generate(Vector3 position, GameObject gameObject)
         * Creates a specified gameObject at
         * specified 3D coordinates.
         * REUSABLE
        */
		public static GameObject Generate(Vector3 position, GameObject gameObject)
        {
            return Object.Instantiate(gameObject, position, Quaternion.identity);
        }
        
        /* Generate(float xCoord, float yCoord, float zCoord, GameObject gameObject)
         * Creates a specified gameObject at
         * specified 3D coordinates.
         * REUSABLE
        */
        public static GameObject Generate(float xCoord, float yCoord, float zCoord, GameObject gameObject)
        {
            Vector3 position = new Vector3(xCoord, yCoord, zCoord);
            return Object.Instantiate(gameObject, position, Quaternion.identity);
        }

        /* Generate(float xCoord, float zCoord, GameObject gameObject)
         * Creates a specified gameObject at
         * specified 2D coordinates.
         * REUSABLE OVERLOAD
        */
        public static GameObject Generate(float xCoord, float zCoord, GameObject gameObject)
        {
            Vector3 position = new Vector3(xCoord, 0, zCoord);
            return Object.Instantiate(gameObject, position, Quaternion.identity);
        }

        /* ToggleVisibility(GameObject[] objectArray, bool state)
         * Changes all gambeObjects in objectArray to state.
         * REUSABLE
        */
        public static void ToggleAllVisibility(GameObject[] objectArray, bool state)
        {
            foreach (GameObject objects in objectArray)
            {
                objects.GetComponent<MeshRenderer>().enabled = state;
            }
        }

        /* ToggleVisibility(Transform gameObject, bool state)
         * Changes gambeObject and all children of gambeObject to state.
         * REUSABLE Overload
        */
        public static void ToggleAllVisibility(Transform gameObject, bool state)
        {
            for (int i = 0; i < gameObject.childCount; i++)
            {
                if (gameObject.GetChild(i).GetComponent<MeshRenderer>() != null)
                {
                    gameObject.GetChild(i).GetComponent<MeshRenderer>().enabled = state;
                }

                if (gameObject.GetChild(i).childCount > 0)
                {
					ToggleAllVisibility(gameObject.GetChild(i), state);
                }
            }
        }

        /* bool DoesTagExist(string tag)
         * Checks if a tag exist in scene.
         * returns true if so, false if not.
         * REUSABLE
        */
        public static bool DoesTagExist(string tag)
        {
            bool exist = false;
            if (GameObject.FindGameObjectWithTag(tag) != null)
            {
                exist = true;
            }

            return exist;
        }

        /* bool DoesNameExist(string name)
         * Checks if a GameObject with name exist in scene.
         * returns true if so, false if not.
         * REUSABLE
        */
        public static bool DoesNameExist(string name)
        {
            bool exist = false;
            if (GameObject.Find(name) != null)
            {
                exist = true;
            }

            return exist;
        }

        /* SetAllActive(GameObject[] objectArray, bool state)
         * Sets all GameObjects in objectArray to state.
         * REUSABLE
        */
        public static void SetAllActive(GameObject[] objectArray, bool state)
        {
            foreach (GameObject objects in objectArray)
            {
                objects.SetActive(state);
            }
        }

    }

    /* Functions for Player Classes */
    public static class PlayerExt
    {
		/* PlayerMovement(Vector3 movement, float ringSpeed, Rigidbody rigidbody)
		 * 2D movement.
		 * REUSABLE
		*/
        public static void PlayerMovement(Vector3 movement, float ringSpeed, Rigidbody rigidbody)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rigidbody.AddForce(movement * ringSpeed);
        }
		
		/* PlayerMovement(Vector3 movement, float ringSpeed, Rigidbody rigidbody)
		 * 2D movement.
		 * REUSABLE
		*/
		public static void PlayerRotation(Vector3 rotation, float ringSpeed, Rigidbody rigidbody)
		{
			float moveHorizontal = Input.GetAxis("Horizontal");

			rotation = new Vector3(0.0f, 0.0f, moveHorizontal);
		}

	}

    /* Functions for Time */
    public static class TimeExt
    {
        /* ToSS(float hours, float minutes, float seconds)
		 * Takes HH, MM, SS and returns in SS.
		 * REUSABLE
		*/
        public static float ToSS(float hours, float minutes, float seconds)
        {
            float timer = seconds + (minutes * 60) + (hours * 3600);
            return timer;
        }

        /* ToSS(float minutes, float seconds)
         * Takes MM, SS and returns in SS.
         * REUSABLE OVERLOAD
        */
        public static float ToSS(float minutes, float seconds)
        {
            float timer = seconds + (minutes * 60);
            return timer;
        }

        /* GameTimer(float gameTime)
         * Recurrsive timer.
         * REUSABLE
        */
        public static float GameTimer(float gameTime)
        {
            float seconds, minutes;

            gameTime += Time.deltaTime;
            minutes = Mathf.Floor(gameTime / 60);
            seconds = gameTime % 60;
            //return minutes.ToString("00") + ":" + seconds.ToString("00.00");
            return gameTime;
        }

        /* float Timer(float time, int ringSpeed)
         * Recurrsive timer with ringSpeed modifier.
         * REUSABLE
        */
        public static float Timer(float time, float ringSpeed)
        {
            time += Time.deltaTime * ringSpeed;
            return time;
        }

        /* CountDownTimer(float time)
         * Recurrsive count down timer.
         * REUSABLE
        */
        public static float CountDownTimer(float time)
        {
            return time -= Time.deltaTime;
        }
    }

    /* Functions for SceneManagement */
    public static class SceneExt
    {
        /* NextScene()
     * Calls the next scene in the build.
     * REUSABLE
    */
        public static void NextScene()
        {
            int totalScenes = SceneManager.sceneCountInBuildSettings;
            int currentsceneIndex = SceneManager.GetActiveScene().buildIndex;

            if (currentsceneIndex != totalScenes - 1)
            {
                SceneManager.LoadScene(currentsceneIndex + 1);
            }
            else
            {
                Debug.Log("On last Scene.");
            }
        }

        /* PreviousScene()
         * Calls the previous scene in the build.
         * REUSABLE
        */
        public static void PreviousScene()
        {
            int currentsceneIndex = SceneManager.GetActiveScene().buildIndex;

            if (currentsceneIndex != 0)
            {
                SceneManager.LoadScene(currentsceneIndex - 1);
            }
            else
            {
                Debug.Log("On first Scene.");
            }
        }

        /* SelectScene(int sceneIndex)
         * Calls the scene in the build at sceneIndex.
         * REUSABLE OVERLOAD
        */
        public static void SelectScene(int sceneIndex)
        {
            int totalScenes = SceneManager.sceneCountInBuildSettings;

            if (sceneIndex >= 0 && sceneIndex < totalScenes)
            {
                Debug.Log("Loading scene: " + sceneIndex);
                SceneManager.LoadScene(sceneIndex);
            }
            else
            {
                Debug.Log("There is no scene at built index " + sceneIndex + ".");
            }
        }

        /* SelectScene(string sceneName)
         * Calls the scene with name sceneName.
         * REUSABLE OVERLOAD
        */
        public static void SelectScene(string sceneName)
        {
            if (DoesSceneExist(sceneName))
            {
                Debug.Log("Loading scene: " + sceneName);
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                Debug.Log("Scene " + sceneName + " does not exist.");
            }
        }

        /* bool DoesSceneExist(string sceneName)
         * Checks if scene sceneName exist in the build.
         * REUSABLE
        */
        public static bool DoesSceneExist(string sceneName)
        {
            int lastSlash;
            string currentName, currentScenePath;

            if (string.IsNullOrEmpty(sceneName))
            {
                return false;
            }

            for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                currentScenePath = SceneUtility.GetScenePathByBuildIndex(i);
                lastSlash = currentScenePath.LastIndexOf("/");
                currentName = (currentScenePath.Substring(lastSlash + 1, currentScenePath.LastIndexOf(".") - lastSlash - 1));

                if (sceneName == currentName)
                {
                    return true;
                }
            }

            return false;
        }
    }

}






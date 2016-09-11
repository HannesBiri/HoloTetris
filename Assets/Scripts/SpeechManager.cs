using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;

public class SpeechManager : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer = null;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    public Transform tower;  // inspector object to hold our tower

    // Use this for initialization
    void Start()
    {
        keywords.Add("Restart game", () =>
        {
            // Call the OnReset method on every descendant object.
            SceneManager.LoadScene(0);
            //this.BroadcastMessage("OnReset");
        });

        keywords.Add("Pause game", () =>
        {
            // Call the OnReset method on every descendant object.
            Time.timeScale = 0.01f;
        });

        keywords.Add("Resume game", () =>
        {
            // Call the OnReset method on every descendant object.
            //this.BroadcastMessage("OnReset");
            Time.timeScale = 1.0f;
        });

        keywords.Add("Tower", PlaceTower);

        keywords.Add("Destroy", DestroyTower);

        // Tell the KeywordRecognizer about our keywords.
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        // Register a callback for the KeywordRecognizer and start recognizing!
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void PlaceTower()
    {
        // Do a raycast into the world based on the user's
        // head position and orientation.
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;

        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            //Quaternion toQuat = Camera.main.transform.localRotation;

            // If the raycast hit a hologram...
            // Display the cursor mesh.
            var towerToPlace = Object.Instantiate(tower);
            towerToPlace.transform.position = hitInfo.point;
            //towerToPlace.transform.rotation = toQuat;
        }
    }

    private void DestroyTower()
    {
        // Do a raycast into the world based on the user's
        // head position and orientation.
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;

        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            if (hitInfo.transform.tag == "Tower")
            {
                var exploder = hitInfo.transform.gameObject.GetComponent<MeshExploder>();
                {
                    exploder.Explode();
                    GameObject.Destroy(hitInfo.transform.gameObject);
                }
            }
        }
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }
}
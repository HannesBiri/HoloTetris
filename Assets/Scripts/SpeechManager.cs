using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechManager : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer = null;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    public Transform tower;

    // Use this for initialization
    void Start()
    {
        keywords.Add("Reset world", () =>
        {
            // Call the OnReset method on every descendant object.
            this.BroadcastMessage("OnReset");
        });

        //keywords.Add("Drop Sphere", () =>
        //{
        //    var focusObject = GazeGestureManager.Instance.FocusedObject;
        //    if (focusObject != null)
        //    {
        //        // Call the OnDrop method on just the focused object.
        //        focusObject.SendMessage("OnDrop");
        //    }
        //});

        keywords.Add("Place Tower", () =>
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
        });


        keywords.Add("Destroy Tower", () =>
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
                }

                //Quaternion toQuat = Camera.main.transform.localRotation;

                    // If the raycast hit a hologram...
                    // Display the cursor mesh.
                    var towerToPlace = Object.Instantiate(tower);
                towerToPlace.transform.position = hitInfo.point;
                //towerToPlace.transform.rotation = toQuat;
            }
        });

        // Tell the KeywordRecognizer about our keywords.
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        // Register a callback for the KeywordRecognizer and start recognizing!
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
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
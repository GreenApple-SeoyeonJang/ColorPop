using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebaseMessagingAPI : MonoBehaviour {
    public void Start()
    {
        if (PlayerPrefs.GetInt("FireBaseMessageAPIOn", 0) == 0)
        {
            Firebase.Messaging.FirebaseMessaging.TokenReceived += OnTokenReceived;
            Firebase.Messaging.FirebaseMessaging.MessageReceived += OnMessageReceived;
            PlayerPrefs.SetInt("FireBaseMessageAPIOn", 1);
        }
    }

    public void OnTokenReceived(object sender, Firebase.Messaging.TokenReceivedEventArgs token)
    {
        Debug.Log("Received Registration Token: " + token.Token);
    }

    public void OnMessageReceived(object sender, Firebase.Messaging.MessageReceivedEventArgs e)
    {
        Debug.Log("Received a new message from: " + e.Message.From);

        var notification = e.Message.Notification;
        if (notification != null)
        {
            Debug.Log("title: " + notification.Title);
            Debug.Log("body: " + notification.Body);

        }
        if (e.Message.From.Length > 0)
            Debug.Log("from: " + e.Message.From);
        if (e.Message.Data.Count > 0)
        {
            Debug.Log("data:");
            foreach (System.Collections.Generic.KeyValuePair<string, string> iter in e.Message.Data)
            {
                Debug.Log("  " + iter.Key + ": " + iter.Value);
            }
        }
    }

}

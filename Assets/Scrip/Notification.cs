using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using Unity.Notifications.Android;
using UnityEngine.Android;

public class Notification : MonoBehaviour
{
    public static Notification instance { get; private set; }
    private const string idCanal = "canalNotificacion";
    public List<string> ListaID { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);

        }
    }


    private void Start()
    {
        ListaID = new List<string>();
        RequestAuhtorization();
        RegisterNotificationChannel("default_channel", "Default", "Notifications");
    }

    //Request authorization to send notifications
    public void RequestAuhtorization()
    {
        if (!Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"))
        {
            Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
        }
    }

    //Register a Notification Channel
    public void RegisterNotificationChannel(string Id, string Name, string Descripcion)
    {
        AndroidNotificationChannel channel = new AndroidNotificationChannel
        {
            Id = Id,
            Name = name,
            Importance = Importance.Default,
            Description = Descripcion
        };
        ListaID.Add(Id);
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }




    //Set Up Notification Template
    public void SendNotification(string title, string text, int fireTimeInHours, bool Gano, int i)
    {
        AndroidNotification notification = new AndroidNotification();
        notification.Title = title;
        notification.Text = text;
        notification.FireTime = DateTime.Now.AddHours(fireTimeInHours);
        notification.SmallIcon = "icon_0";
        notification.LargeIcon = "icon_1";

        AndroidNotificationCenter.SendNotification(notification, ListaID[i]);
    }




    public void ButtonFunction()
    {
        SendNotification("Dummy Notification", "This is a sample Notification", 0, true, 0);
    }
}


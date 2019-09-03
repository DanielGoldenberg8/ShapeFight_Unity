using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageManager : MonoBehaviour
{
    public GameObject chatPanel;
    public GameObject textObject;

    private List<Message> messageList = new List<Message>();

    private int message;

    public static MessageManager instance;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void SendMessageToChat(string text, Message.Color color)
    {
        Invoke("HideMessge", 6f);

        Message newMessage = new Message();

        newMessage.text = text;

        GameObject newText = Instantiate(textObject, chatPanel.transform);

        newMessage.textObject = newText.GetComponent<TextMeshProUGUI>();

        newMessage.textObject.text = newMessage.text;
        newMessage.textObject.color = MessageTypeColor(color);
            
        messageList.Add(newMessage);
    }

    void HideMessge()
    {
        Destroy(messageList[0].textObject.gameObject, 6f);
        messageList.Remove(messageList[0]);
    }

    Color MessageTypeColor(Message.Color messageType)
    {
        Color color = Colors.instance.white;

        switch (messageType)
        {
            case Message.Color.white:
                color = Colors.instance.white;
                break;
            case Message.Color.blue:
                color = Colors.instance.blue;
                break;
            case Message.Color.red:
                color = Colors.instance.red;
                break;
            case Message.Color.purple:
                color = Colors.instance.purple;
                break;
            case Message.Color.green:
                color = Colors.instance.green;
                break;
            case Message.Color.orange:
                color = Colors.instance.orange;
                break;
            case Message.Color.yellow:
                color = Colors.instance.yellow;
                break;
        }

        return color;
    }
}

[System.Serializable]
public class Message
{
    public TextMeshProUGUI textObject;
    public string text;

    public enum Color 
    {
        white, 
        blue,
        red,
        purple,
        green,
        orange,
        yellow
    };
    public Color color;
}
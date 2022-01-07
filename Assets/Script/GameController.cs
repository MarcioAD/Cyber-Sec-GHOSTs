using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //_UI reference_//
    public Text displayText;

    [HideInInspector] public RoomNavigation roomNavigation;
    [HideInInspector] public List<string> interactionsDescriptionsInRoom =  new List<string>();
    
    //_Create a list_//
    List<string> actionslog = new List<string>();

    //_GET component of UNITY named ROOMNAVIGATION_//
    void Awake()
    {
        roomNavigation = GetComponent<RoomNavigation>();
    }

    //_Initialize and execute functions_//
    void Start()
    {
        DisplayRoomText();
        DisplayLoggedtext();
    }

    //_Function Show Display text_//
    public void DisplayLoggedtext()
    {
        

        string logAsText = string.Join("\n", actionslog.ToArray());

        displayText.text = logAsText;
    }

    //_GET text description of room_//
    public void DisplayRoomText()
    {
        UnpackRoom();

        string joinedInteracrionDescriptions = string.Join("\n", interactionsDescriptionsInRoom.ToArray());

        string combinedText = roomNavigation.currentRoom.description + "\n" + joinedInteracrionDescriptions;

        LogsStringWithReturn (combinedText);
    }

    void UnpackRoom()
    {
        roomNavigation.UnpackExitsInRoom();
    }

    //_Create a function for add logs a list_//
    public void LogsStringWithReturn(string stringToAdd)
    {
        actionslog.Add( stringToAdd + "\n" );
    }

}

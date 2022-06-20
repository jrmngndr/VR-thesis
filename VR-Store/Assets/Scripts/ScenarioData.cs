using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioData : MonoBehaviour
{
    //split into classes
    public static float playerSpeed = 10f;
    public static float mouseSensitivity = 70f;
    public static float messageDelay = 1f;
    public static float pickupRange = 1f;
    public static float xRotation = 0f;
    public static float xRotationMin = -40f;
    public static float xRotationMax = 30f;
    public static float timer = 0f;

    public static bool timerEnabled = false;
    public static bool started = false;

    public static string startMessage = "STARTED";
    public static string finishMessage = "FINISHED";

    public static Text text;
    public static Text timerText;

    public static GameObject player;
    public static GameObject playerHeldItem;
    public static GameObject mainCamera;
    public static Transform playerTransform;
    public static Transform itemHolder;
    public static CharacterController playerController;
    

    private void OnEnable()
    {
        player = GameObject.Find("PlayerPov");
        playerTransform = player.transform;
        playerController = player.GetComponent<CharacterController>();
        mainCamera = GameObject.Find("Main Camera");
        text = GameObject.Find("StartText").GetComponent<Text>();
        timerText = GameObject.Find("TimerText").GetComponent<Text>();
        itemHolder = GameObject.Find("ItemHolder").transform;
    }
}

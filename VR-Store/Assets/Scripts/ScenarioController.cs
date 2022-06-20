using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioController : MonoBehaviour
{

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    //rewrite to use events
    //move some stuff to UI
    void Update()
    {
        if (ScenarioData.timerEnabled) ScenarioData.timer += Time.deltaTime;

        if (Input.GetButtonDown("t"))
        {
            ScenarioData.timerText.enabled = !ScenarioData.timerText.enabled;
        }

        if (Input.GetButtonDown("q"))
        {
            Debug.Log("QUIT");
            Application.Quit();
        }
    }

    private void OnGUI()
    {
        if (ScenarioData.timerText.enabled) ScenarioData.timerText.text = ScenarioData.timer.ToString();
    }

    private void OnEnable()
    {
        GameStart.OnStartTrigger += OnStart;
        ItemContact.OnItemTrigger += EndGame;
    }

    private void OnDisable()
    {
        GameStart.OnStartTrigger -= OnStart;
        ItemContact.OnItemTrigger -= EndGame;
    }

    private void OnStart()
    {
        if (!ScenarioData.started)
        {
            ScenarioData.started = true;
            StartCoroutine(ShowMessage(ScenarioData.startMessage, ScenarioData.messageDelay));
            StartTimer();
        }
    }


    private void EndGame(Collider other)
    {
        if (other.transform.CompareTag("item"))
        {
            StartCoroutine(ShowMessage(ScenarioData.finishMessage, ScenarioData.messageDelay));
            StopTimer();
            StartCoroutine(Quit(ScenarioData.messageDelay * 5));
        };
    }

    private void StartTimer()
    {
        ScenarioData.timerEnabled = true;
    }

    private void StopTimer()
    {
        ScenarioData.timerEnabled = false;
        ScenarioData.timer = 0f;
    }

    IEnumerator Quit(float delay)
    {
        yield return new WaitForSeconds(delay);
        Application.Quit();
    }

    IEnumerator ShowMessage(string message, float delay)
    {
        ScenarioData.text.text = message;
        Debug.Log(ScenarioData.text.text);
        ScenarioData.text.enabled = true;
        yield return new WaitForSeconds(delay);
        ScenarioData.text.enabled = false;
    }


}

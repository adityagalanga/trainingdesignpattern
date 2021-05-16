using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public GameObject actor;
    Animator anim;
    Command KeyQ, KeyW, KeyE,upArrow;
    List<Command> oldCommands = new List<Command>();

    Coroutine replayCoroutine;
    bool shouldStartReplay;
    bool isReplaying;

    void Start()
    {
        KeyQ = new PerformJump();
        KeyW = new PerformKick();
        KeyE = new PerformPunch();
        anim = actor.GetComponent<Animator>();
        Camera.main.GetComponent<CameraFollow360>().player = actor.transform;
        upArrow = new MoveFoward();
    }

    void Update()
    {
        if (!isReplaying)
        {
            HandleInput();
        }
        StartReplay();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            KeyQ.Execute(anim);
            oldCommands.Add(KeyQ);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            KeyW.Execute(anim);
            oldCommands.Add(KeyW);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            KeyE.Execute(anim);
            oldCommands.Add(KeyE);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            upArrow.Execute(anim);
            oldCommands.Add(upArrow);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            shouldStartReplay = true;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            UndoLastCommand();
        }
    }

    void UndoLastCommand()
    {
        Command c = oldCommands[oldCommands.Count - 1];
        c.Execute(anim);
        oldCommands.RemoveAt(oldCommands.Count - 1);
    }
    void StartReplay()
    {
        if(shouldStartReplay && oldCommands.Count > 0)
        {
            shouldStartReplay = false;
            if(replayCoroutine != null)
            {
                StopCoroutine(replayCoroutine);
            }
            replayCoroutine = StartCoroutine(ReplayCommands());
        }
    }

    IEnumerator ReplayCommands()
    {
        isReplaying = true;

        for(int i = 0; i < oldCommands.Count; i++)
        {
            oldCommands[i].Execute(anim);
            yield return new WaitForSeconds(1f);
        }

        isReplaying = false;
    }
}

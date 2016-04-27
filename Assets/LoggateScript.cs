using UnityEngine;
using System.Collections;

public enum LoggateState { OPENING, OPEN,CLOSINGBEGIN, CLOSING, CLOSED}

public class LoggateScript : MonoBehaviour {

    LoggateState state;
	// Use this for initialization
	void Start () {
        state = LoggateState.CLOSED;
	}

    public void Open()
    {
        if (state != LoggateState.CLOSED)
            return;

        state = LoggateState.OPENING;
    }

    public void Close()
    {
        if (state != LoggateState.OPEN && state != LoggateState.CLOSINGBEGIN)
            return;

        state = LoggateState.CLOSING;
    }
	
	// Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case (LoggateState.CLOSED):
                {
                    break;
                }
            case (LoggateState.OPENING):
                {
                    transform.Rotate(-25 * Time.deltaTime, 0,0);

                    if (transform.eulerAngles.x <= 10 || transform.eulerAngles.x > 300)
                        state = LoggateState.OPEN;

                    break;
                }
            case (LoggateState.OPEN):
                {
                    Invoke("Close", 5);
                    state = LoggateState.CLOSINGBEGIN;
                    break;
                }
            case (LoggateState.CLOSINGBEGIN):
                {
                    break;
                }
            case (LoggateState.CLOSING):
                {
                    transform.Rotate(45 * Time.deltaTime, 0, 0);

                    if (transform.eulerAngles.x >= 90 && transform.eulerAngles.x < 300)
                        state = LoggateState.CLOSED;
                    break;
                }
        }
    }
}

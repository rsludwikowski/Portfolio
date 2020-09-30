using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeChangeableObject : MonoBehaviour
{
    public int playerIndex = 1;
    public Rigidbody TimeChangeableObjectBody;
    public State state;
    public enum State
    {
        Normal,
    }

    private void Start()
    {
        TimeChangeableObjectBody = GetComponent<Rigidbody>();
        state = State.Normal;
    }

    private void Update()
    {
        switch (state)
        {
            case State.Normal:
                break;
        }
    }

    public void slow()
    {
        print("PENIS TAKI DLUGI ZE GO ODBIJAM KOLANEM");
    }
    public void haste()
    {
        print("haste");
    }
}

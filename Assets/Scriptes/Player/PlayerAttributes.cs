using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public enum Statement { Alive, Dead };
    public enum Action {Idle, Attack, Defend };

    public enum IsGoing { Idle, Running};

    public Statement live;
    public Action action;
    public IsGoing isGoing;

}

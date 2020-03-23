using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IdleState", menuName = "UNITY-FSM/States/Idle", order = 1)]
public class IdleState : AbstractFSMState {
    public override bool EnterState() {
        base.EnterState();

        Debug.Log("IDLE 상태에 진입했습니다");

        EnteredState = true;
        return EnteredState;
    }

    public override void UpdateState() {
        Debug.Log("IDLE UPDATE");
    }

    public override bool ExitState() {
        base.ExitState();
        Debug.Log("IDLE 상태를 나갑니다");
        return true;
    }
}

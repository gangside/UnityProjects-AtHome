using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoveState", menuName = "UNITY-FSM/States/Move", order = 2)]
public class MoveState : AbstractFSMState {

    public Transform tr;
    public Vector3 toPoint;
    public float velocity;

    public override void OnEnable() {
        base.OnEnable();
    }

    public override bool EnterState() {

        EnteredState = false;

        if (base.EnterState()) {
            //MoveState를 위한 선행조건 확인 및 설정
            bool test = true;
            if (!test) EnteredState = false;
            else {
                EnteredState = true;
            }
        }

        return EnteredState;
    }

    public override void UpdateState() {
        //TODO : 성공적으로 업데이트 스테이트에 들어왔는지 확인
        if (EnteredState) {
            //LOGIC
        }
    }

    private void SetDestination(Vector3 toPoint) {
        throw new NotImplementedException();
    }
}

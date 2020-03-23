using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ExecutionState {
    NONE,
    ACTIVE,
    COMPLETED,
    TERMINATED,
};

public abstract class AbstractFSMState : ScriptableObject
{
    public ExecutionState ExecutionState { get; protected set; }
    public bool EnteredState { get; protected set; }

    public virtual void OnEnable() {
        ExecutionState = ExecutionState.NONE;
    }

    public virtual bool EnterState() {
        bool successOne = true;
        bool successTwo = true;
        ExecutionState = ExecutionState.ACTIVE;

        //successOne = (조건);
        //successTwo = (조건);

        return successOne & successTwo;
    }


    public abstract void UpdateState();

    public virtual bool ExitState() {
        ExecutionState = ExecutionState.COMPLETED;
        return true;
    }
}

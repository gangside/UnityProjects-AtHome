using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof( FiniteStateMacine ))]
public class NPC : MonoBehaviour
{
    FiniteStateMacine _finiteStateMacine;

    private void Awake() {
        _finiteStateMacine = GetComponent<FiniteStateMacine>();
    }

    private void Start() {
        
    }

    private void Update() {
        
    }
}

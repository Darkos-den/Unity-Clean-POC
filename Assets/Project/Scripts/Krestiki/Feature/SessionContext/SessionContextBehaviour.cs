using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SessionContextBehaviour : MonoBehaviour {

    [Inject]
    private ISessionContextController _controller;

    void Start() {
    }

    void Update() {
        
    }
}

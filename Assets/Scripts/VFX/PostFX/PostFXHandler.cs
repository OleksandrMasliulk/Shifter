using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PostFXHandler : MonoBehaviour {
    private Dictionary<IEnumerator, Coroutine> _coroutines;

    private void Awake() {
        _coroutines = new Dictionary<IEnumerator, Coroutine>();
    }

    public void RunEffect(IEnumerator numerator) {
        if (_coroutines.TryGetValue(numerator, out Coroutine coroutine)) {
            StopCoroutine(coroutine);
        }

        StartCoroutine(numerator);
    }
}

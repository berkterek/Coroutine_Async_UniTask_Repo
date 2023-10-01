using System.Collections;
using UnityEngine;

public class CoroutineSample3 : MonoBehaviour
{
    [SerializeField] float _delayTime = 0.5f;
    [SerializeField] Transform _transform;
    [SerializeField] float _speed = 100f;

    void OnValidate()
    {
        if (_transform == null) _transform = transform;
    }

    void Start()
    {
        StartCoroutine(StartInfiniteRotationAsync());
    }

    private IEnumerator StartInfiniteRotationAsync()
    {
        var wait = new WaitForSeconds(_delayTime);
        while (true)
        {
            _transform.Rotate(_speed*Time.deltaTime*Vector3.up);
            //yield return new WaitForSeconds(_delayTime);
            yield return wait;
        }
    }
}
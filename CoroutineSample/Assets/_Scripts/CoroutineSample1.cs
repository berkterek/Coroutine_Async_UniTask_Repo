using System.Collections;
using UnityEngine;

public class CoroutineSample1 : MonoBehaviour
{
    [SerializeField] Transform _transform;
    [SerializeField] float _speed = 100f;

    void OnValidate()
    {
        if (_transform == null) _transform = transform;
    }

    [ContextMenu(nameof(StartInfiniteRotation))]
    public void StartInfiniteRotation()
    {
        StartCoroutine(StartInfiniteRotationAsync());
    }

    private IEnumerator StartInfiniteRotationAsync()
    {
        while (true)
        {
            _transform.Rotate(_speed*Time.deltaTime*Vector3.up);
            yield return null;
        }
    }
}
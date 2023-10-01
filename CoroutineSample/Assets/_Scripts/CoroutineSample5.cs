using System.Collections;
using UnityEngine;

public class CoroutineSample5 : MonoBehaviour
{
    [SerializeField] bool _waitUntil = false;
    [SerializeField] Transform _transform;
    [SerializeField] float _speed = 100f;

    void OnValidate()
    {
        if (_transform == null) _transform = transform;
    }

    IEnumerator Start()
    {
        Debug.Log("<color=green>Wait 2 second started</color>");
        yield return new WaitForSeconds(2f);
        Debug.Log("<color=red>Wait 2 second ended</color>");
        
        Debug.Log("<color=green>Wait until started</color>");
        yield return new WaitUntil(() => _waitUntil);
        // yield return new WaitUntil(() =>
        // {
        //     return _waitUntil;
        // });
        Debug.Log("<color=red>Wait Until ended</color>");
        
        yield return StartInfiniteRotationAsync();
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
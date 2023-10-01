using System.Collections;
using UnityEngine;

public class CoroutineSample4 : MonoBehaviour
{
    [SerializeField] Transform _transform;
    [SerializeField] float _speed = 100f;

    Coroutine _coroutine;

    void OnValidate()
    {
        if (_transform == null) _transform = transform;
    }

    void Start()
    {
        _coroutine = StartCoroutine(StartInfiniteRotationAsync());
    }

    private IEnumerator StartInfiniteRotationAsync()
    {
        while (true)
        {
            _transform.Rotate(_speed*Time.deltaTime*Vector3.up);
            yield return null;
        }
    }

    [ContextMenu(nameof(CancelThis1Coroutine))]
    public void CancelThis1Coroutine()
    {
        if(_coroutine != null) StopCoroutine(_coroutine);
        
        //butun calisan coroutine'leri durdurur
        //StopAllCoroutines();
    }
}
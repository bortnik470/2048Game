using System.Collections;
using UnityEngine;

public class CreateNewCube : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private InterstialAd _interstialAd;

    private IEnumerator CreatingProcces()
    {
        yield return new WaitForSeconds(1.1f);
        Instantiate(_cubePrefab, new Vector3(0, 0.2f, -2.1f), Quaternion.identity);
        _interstialAd.AddShotToCount();
    }

    public void CreateCube()
    {
        StartCoroutine(CreatingProcces());
    }
}
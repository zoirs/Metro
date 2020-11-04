using UnityEngine;
using Zenject;

public class TrainController : MonoBehaviour {
    private GameObject _line;
    private LineRenderer _lineRenderer;
    private int index;
    private Vector3 _dir;

    private void Start() {
        _line = GameObject.Find("newLines");
        _lineRenderer = _line.GetComponent<LineRenderer>();
        transform.position = _lineRenderer.GetPosition(index);
    }

    private void Update() {
        _dir = _lineRenderer.GetPosition(index) - transform.position;
        float dist = Vector3.Distance(_lineRenderer.GetPosition(index), transform.position);
        if (dist <= 0.1f) {
            index++;
        }
        transform.Translate(_dir.normalized * 1f * Time.deltaTime);
    }

    public class Factory : PlaceholderFactory<TrainController> { }
}
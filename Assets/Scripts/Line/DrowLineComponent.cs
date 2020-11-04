using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DrowLineComponent : MonoBehaviour {
        private LineRenderer _lineRenderer;
        private List<Vector2> fingerPosition = new List<Vector2>();
        private bool _created;
        private bool _inprogress;
        private bool _completed;

        public class Factory : PlaceholderFactory<DrowLineComponent> { }


        private void Start() {
                Debug.Log("Инит");
                
                _lineRenderer = GetComponent<LineRenderer>();
                fingerPosition = new List<Vector2>();
                _created = true;
        }

        private void Create() {
                fingerPosition.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                fingerPosition.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                _lineRenderer.SetPosition(0, fingerPosition[0]);
                _lineRenderer.SetPosition(1, fingerPosition[1]);
        }

        public void AddPoint(Vector2 pointPosition) {
                fingerPosition.Add(pointPosition);
                _lineRenderer.positionCount++;
                _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, pointPosition);

        }

        private void Update() {
                if (!_created || _completed) {
//                        Debug.Log("Не создано");
                        return;
                }

                if (Input.GetMouseButtonDown(0)) {
                        Debug.Log("Создать");
                        Create();
                        _inprogress = true;
                }
                if (Input.GetMouseButton(0)) {
                        Vector2 tmpPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                        if (Vector2.Distance(tmpPosition, fingerPosition[fingerPosition.Count - 1]) > 5) {
                                Debug.Log("Добавить " + tmpPosition);
                                AddPoint(getPoint(fingerPosition[fingerPosition.Count - 1], tmpPosition));
                                AddPoint(tmpPosition);
                        }
                }

                if (Input.GetMouseButtonUp(0) && _inprogress) {
                        Debug.Log("Завершено");
                        _completed = true;
                }

        }

        public Vector2 getPoint(Vector2 f, Vector2 s) {
                Debug.Log("1 " + f + " , 2 "+ s);
                float k;
                if (f.x > s.x && f.y > s.y || f.x < s.x && f.y < s.y) {
                         k = 1f;
                        
                }
                else {
                         k = -1f;                        
                }

                //y-y0=k(x-x0)
                //kx-kx0-y+y0=0 
                //kx-y+y0-kx0=0 
                // y - 12 = x - 12
                //x-y-0 1,-1,0 12 12
                float fa = k;
                float fb = -1;
                float fc = - k * f.x + f.y;
                Debug.Log(fa + "*x + " + fb + "*y + " + fc);
                
                
                float sa;
                float sb;
                float sc;
                if (Math.Abs(f.x - s.x) > Math.Abs(f.y - s.y)) {
                        //горизонтально //y=3
                        sa = 0;
                        sb = -1;
                        sc = s.y;
                }
                else {
                        // x=3
                        //
                        sa = 1;
                        sb = 0;
                        sc = -s.x;
                }

                Debug.Log(sa + "*x + " + sb + "*y + " + sc);

                float x = -(fc * sb - sc * fb) / (fa * sb - sa * fb);
                float y = -(fa * sc - sa * fc) / (fa * sb - sa * fb);





                return new Vector2(x,y);
        }
}
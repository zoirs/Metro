using System;
using UnityEngine;
using Zenject;

public class PlaneController : MonoBehaviour {
    [Inject] private LineElementController.Factory _factory;

    private Vector3 _currentClick;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            _currentClick = Input.mousePosition;
            Vector3 position = Camera.main.ScreenToWorldPoint(_currentClick);

            if (position.x < 5 || position.x > 15) {
                return;
            }

            LineElementController lineElement = _factory.Create();
            
            int quota = 0;
            
            float ymod5 = (float) (position.y % 1);
            float xmod5 = (float) (position.x % 1);
//            Debug.Log("позиция "+position.x+ " "+position.y);
//            Debug.Log("поз мод " + xmod5 + " " + ymod5 );
            if (ymod5 < 0.5 && xmod5 < 0.5) {
                quota = 1;
            }
            if (ymod5 < 0.5 && xmod5 > 0.5) {
                quota = 2;                
            }
            if (ymod5 > 0.5 && xmod5 > 0.5) {
                quota = 3;
            }
            if (ymod5 > 0.5 && xmod5 < 0.5) {
                quota = 4;
            }
            Debug.Log("четверть " +quota);

            if (quota == 1) {
                if (Math.Abs(ymod5) < Math.Abs(xmod5)) {
                    //горизонтально
                    lineElement.transform.RotateAround(
                        lineElement.transform.position , Vector3.forward, 90);
                    lineElement.transform.position = new Vector3((int)Math.Round(position.x), (int)Math.Round(position.y)) + new Vector3(0.5f, 0f);
                }
                else {
                    lineElement.transform.RotateAround(
                        lineElement.transform.position , Vector3.forward, 0);
                    lineElement.transform.position = new Vector3((int)Math.Round(position.x), (int)Math.Round(position.y)) + new Vector3(0, 0.5f);
                }
            }
            if (quota == 2) {
                if (ymod5 < 1 - xmod5) {
                    //горизонтально
                    lineElement.transform.RotateAround(
                        lineElement.transform.position , Vector3.forward, 90);
                    lineElement.transform.position = new Vector3((int)Math.Round(position.x), (int)Math.Round(position.y)) + new Vector3(-0.5f, 0f);
                }
                else {
                    lineElement.transform.RotateAround(
                        lineElement.transform.position , Vector3.forward, 0);
                    lineElement.transform.position = new Vector3((int)Math.Round(position.x), (int)Math.Round(position.y)) + new Vector3(0, 0.5f);
                }
            }
            if (quota == 3) {
                if (ymod5 > xmod5) {
                    //горизонтально
                    lineElement.transform.RotateAround(
                        lineElement.transform.position , Vector3.forward, 90);
                    lineElement.transform.position = new Vector3((int)Math.Round(position.x), (int)Math.Round(position.y)) + new Vector3(-0.5f, 0f);
                }
                else {
                    lineElement.transform.RotateAround(
                        lineElement.transform.position , Vector3.forward, 0);
                    lineElement.transform.position = new Vector3((int)Math.Round(position.x), (int)Math.Round(position.y)) + new Vector3(0, -0.5f);
                }
            }
            
            if (quota == 4) {
                if (ymod5 > 1 - xmod5) {
                    //горизонтально
                    lineElement.transform.RotateAround(
                        lineElement.transform.position , Vector3.forward, 90);
                    lineElement.transform.position = new Vector3((int)Math.Round(position.x), (int)Math.Round(position.y)) + new Vector3(0.5f, 0f);
                }
                else {
                    lineElement.transform.RotateAround(
                        lineElement.transform.position , Vector3.forward, 0);
                    lineElement.transform.position = new Vector3((int)Math.Round(position.x), (int)Math.Round(position.y)) + new Vector3(0, -0.5f);
                }
            }
        }
    }
}
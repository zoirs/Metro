using System;
using UnityEngine;
using Zenject;

public class MoneyService : IInitializable, IDisposable {
    
    [Inject] private ScreenService _screen;
    
    public void Initialize() {
        Debug.Log(_screen);    
    }

    public void Dispose() {
        
    }
}
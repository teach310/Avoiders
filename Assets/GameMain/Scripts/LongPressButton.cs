using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class LongPressButton : MonoBehaviour {

    BoolReactiveProperty isPointerDown = new BoolReactiveProperty();

    public IReadOnlyReactiveProperty<bool> IsPointerDown{
        get{return isPointerDown;}
    }

    void Start()
    {
        var eventTrigger = this.gameObject.AddComponent<ObservableEventTrigger>();
        eventTrigger.OnPointerDownAsObservable()
                    .Subscribe(x=>isPointerDown.Value = true);
        eventTrigger.OnPointerUpAsObservable()
                    .Subscribe(x=>isPointerDown.Value = false);
    }
}

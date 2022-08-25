using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CDIndicator : MonoBehaviour {
    [SerializeField] private Slider _indicator;
    private IRechargable _rechargeble;

    [Inject]
    public void Construct(IRechargable rechargable) {
        _rechargeble = rechargable;
    }

    private void Awake() {
        _indicator.minValue = 0f;
        _indicator.maxValue  = 1f;
    }

    private void Update() {
        if (_rechargeble.TimeToRecharge > 0)
            UpdateIndicator();
    }

    private void UpdateIndicator() {
        _indicator.value = 1 - (_rechargeble.TimeToRecharge / _rechargeble.RechargeTime);
    }
}

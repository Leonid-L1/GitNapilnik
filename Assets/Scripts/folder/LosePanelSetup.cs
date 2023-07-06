using UnityEngine;

[RequireComponent(typeof(LosePanelView))]

public class LosePanelSetup : MonoBehaviour
{
    private LosePanelView _view;
    private LosePanelModel _model;
    private LosePanelPresenter _presenter;

    private void OnDisable() => _presenter.Disable();

    public void Init(int currentLevelNumber)
    {
        _view = GetComponent<LosePanelView>();
        _model = new LosePanelModel(currentLevelNumber);
        _presenter = new LosePanelPresenter(_view, _model);
        _presenter.Enable();
    }    
}

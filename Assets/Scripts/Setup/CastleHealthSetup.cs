using UnityEngine;

[RequireComponent(typeof(CastleHealthView))]
public class CastleHealthSetup : MonoBehaviour
{
    private CastleHealthView _view;
    private CastleHealthPresenter _presenter;
    private CastleHealthModel _model;

    public void Init(int health, LosePanelView losePanel)
    {
        _view = GetComponent<CastleHealthView>();
        _view.Init(health);
        _model = new CastleHealthModel(health);
        _presenter = new CastleHealthPresenter(_view, _model,losePanel);
        _presenter.Enable();
    }

    private void OnDisable() => _presenter.Disable();
    
}

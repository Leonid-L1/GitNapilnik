using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(CellView))]
[RequireComponent(typeof(BoxCollider))]
public class CellSetup : MonoBehaviour
{
    [SerializeField] private PlatformView _platform;
    [SerializeField] private Timer _timer;

    private MeshRenderer _renderer;
    private CellView _view;
    private BoxCollider _collider;
    private CellModel _model;
    private CellPresenter _presenter;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
        _view = GetComponent<CellView>();
        _collider = GetComponent<BoxCollider>();
        _model = new CellModel(_platform,_collider,transform.position, _renderer.material.color);
        _presenter = new CellPresenter(_model, _view);
        _timer.AddUpdatable(_presenter);
    }

    private void OnEnable() => _presenter.Enable();
    private void OnDisable() => _presenter.Disable(); 

}

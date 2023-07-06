using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WarriorSpawnerView))]
public class WarriorSpawnerSetup : MonoBehaviour
{
    [SerializeField] private List<GameObject> _meleeWarriorsByLevel;
    [SerializeField] private List<GameObject> _rangeWarriorsByLevel;

    private WarriorSpawnerPresenter _presenter;
    private WarriorSpawnerModel _model;
    private WarriorSpawnerView _view;

    private void Awake()
    {
        _view = GetComponent<WarriorSpawnerView>();

        _model = new WarriorSpawnerModel(_meleeWarriorsByLevel, _rangeWarriorsByLevel);
        _presenter = new WarriorSpawnerPresenter(_view, _model);
    }

    private void OnEnable() => _presenter.Enable();

    private void OnDisable() => _presenter.Disable();
}

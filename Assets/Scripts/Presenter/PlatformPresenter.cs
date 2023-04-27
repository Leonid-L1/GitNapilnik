using System.Collections.Generic;

public class PlatformPresenter : IPresenter, Updatable
{
    private PlatformView _view;
    private PlatformModel _model;

    public PlatformPresenter(PlatformView view, PlatformModel model)
    {
        _view = view;
        _model = model;
    }

    public void Enable()
    {
        _model.IsFull += OnFull;
        _view.BlockDropped += OnBLockDropped;
    }

    public void Disable()
    {
        _model.IsFull -= OnFull;
        _view.BlockDropped -= OnBLockDropped;
    }

    public void Update(float deltaTime)
    {   
        _view.SetIsAbleToTake(_model.GetIsAbleToTake(_view.SelectedBlock));
    }

    private void OnFull(List<BlockView> blocksOnPlatform)
    {
        foreach (var block in blocksOnPlatform)
            block.RemoveFromPlatform();
    }

    private void OnBLockDropped(BlockView block)
    {
        _model.PutBlock(block);
        block.Drop();
    }
}

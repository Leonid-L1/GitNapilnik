
public class CharacterHealthPresenter : IPresenter
{
    private CharacterHealthModel _model;
    private CharacterHealthView _view;
    private CharacterAnimationModel _animationModel;
    
    public CharacterHealthPresenter(CharacterHealthModel model, CharacterHealthView view, CharacterAnimationModel animationModel)
    {
        _model = model;
        _view = view;
        _animationModel = animationModel;
    }

    public void Enable()
    {
        _view.DamagedRecieved += _model.ApplyDamage;
        _model.HealthChanged += _view.ShowHealth;
        _model.Death += _animationModel.OnDeath;   
    }

    public void Disable()
    {
        _view.DamagedRecieved -= _model.ApplyDamage;
        _model.HealthChanged += _view.ShowHealth;
        _model.Death -= _animationModel.OnDeath;
    }
}

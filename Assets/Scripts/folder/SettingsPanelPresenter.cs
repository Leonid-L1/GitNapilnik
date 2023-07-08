public class SettingsPanelPresenter 
{
    private SettingsPanelView _view;
    private SettingsPanelModel _model;

    public SettingsPanelPresenter(SettingsPanelView view, SettingsPanelModel model)
    {
        _view = view;
        _model = model;
    }

    public void Enable()
    {
        _view.MusicVolumeChangeRequested += _model.ChangeMusicVolume;
        _view.EffectsVolumeChangeRequested += _model.ChangeEffectsVolume;
        _view.LanguageChangeRequested += _model.ChangeLanguage;
        _model.LanguageChanged += _view.UpdateLanguageButton;
    }

    public void Disable()
    {
        _view.MusicVolumeChangeRequested -= _model.ChangeMusicVolume;
        _view.EffectsVolumeChangeRequested -= _model.ChangeEffectsVolume;
        _view.LanguageChangeRequested -= _model.ChangeLanguage;
        _model.LanguageChanged -= _view.UpdateLanguageButton;
    }
}
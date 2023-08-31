using Zenject;

public class SessionContextController : ISessionContextController {

    private ISessionUseCase _useCase;

    [Inject]
    public SessionContextController(ISessionUseCase useCase) {
        _useCase = useCase;

        _useCase.InitSession();
    }
}


namespace BaseApi.UseCase.V1
{
    public static class ThrowOpsErrorUsecase
    {
        public static void Execute()
        {
            throw new TestOpsErrorException();
        }
    }
}

namespace F23L034_GestContact_Cqs.WebApp.Infrastructure
{
    public interface ISessionManager
    {
        UserInfo? UserInfo { get; set; }
        void Clear();
    }
}
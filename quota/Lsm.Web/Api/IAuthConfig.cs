namespace DoE.Lsm.Web.Api.Auth
{
    public interface IAuthConfig
    {
        IAuthConfig ConfigureRole(string role);
        IAuthConfig ConfigureUser(string user, string assignedRole);
    }
}

using SN;
 
public class theController 
{
    private struct user
    {
        public string username;
        public string password;
        public string session_id;
    }
    [Request("ping")]
    public string ping(SN.RequestInfo request)
    {
        return "";
    }
    [Request("login")]
    public string login(SN.RequestInfo request)
    {
        string username = request.msg[0];
        string password = request.msg[1];

        if (SN.Sessions.Current[request.sid].ContainsKey("user"))
            return "You are already logged in.";
        if (username != null && password != null)
        {

            try
            {
                if (utility.database.Query("select password from Users where username = '" + username + "';")[0]["password"] == password)
                {
                    SN.Sessions.Current[request.sid]["user"] = new user { username = username, password = password, session_id = request.sid };
                    return "ok";
                }
                else
                {

                    return "Wrong password.";
                }
            }
            catch
            {

                return "Wrong username";
            }
        }
        else
        {
            return "Invalid data.";
        }

    }
    [Request("query")]
    public dynamic qr(SN.RequestInfo request)
    {
        if (!SN.Sessions.Current[request.sid].ContainsKey("user"))
            return "you have to be logged in";

        return utility.database.Query(request.msg);
    }
    [Request("logout")]
    public string lout(SN.RequestInfo request)
    {
        if (SN.Sessions.Current[request.sid].ContainsKey("user"))
        {
            SN.Sessions.Current[request.sid]["user"] = null; 
        }
        return "ok";
    }

}

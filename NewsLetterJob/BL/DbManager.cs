using Npgsql;

namespace NewsLetterJob.BL
{
    public class DbManager
    {
        NpgsqlConnection dbconn()
        {
            string cs = "Host=abul.db.elephantsql.com;Port=5432;Database=odkihpmm;Username=odkihpmm;Password=aQO6Uxbk6XXfxq46E9PfYBi-HWn_a6mP;";
            using var con = new NpgsqlConnection(cs);

            return con;
        }

        public string GetMessageBody()
        {
            try
            {
                string cs = "Host=abul.db.elephantsql.com;Port=5432;Database=odkihpmm;Username=odkihpmm;Password=aQO6Uxbk6XXfxq46E9PfYBi-HWn_a6mP;";
                using var con = new NpgsqlConnection(cs);
                con.Open();

                string sql = "SELECT id, \"Denumire\", \"Cost\", \"Tva\", \"Acciz\", \"Marime\", \"Reducere\", \"Culoare\" FROM public.\"Produs\" where \"Reducere\" > 0 and \"EndReducere\" > now() and \"StartReducere\" < now()";

                using var cmd = new NpgsqlCommand(sql, con);  
                using var reader = cmd.ExecuteReader();

                var result = "";

                while (reader.Read())
                {
                    var pret = reader.GetDouble(2) + reader.GetDouble(3) * reader.GetDouble(2) / 100 + reader.GetDouble(4) * reader.GetDouble(2) / 100;
                    result += @$"<h1>{reader.GetString(1)}</h1>
                       <span style='color:green; margin-right:10px'>-{reader.GetDouble(6)}%</span>
                       <span style='color:red'>pret {pret} lei</span><br>";
                }

                return result;
            }
            catch
            {
                throw new Exception();
            } 
        }


        public List<string> GetEmailsList()
        {
            try
            {
                string cs = "Host=abul.db.elephantsql.com;Port=5432;Database=odkihpmm;Username=odkihpmm;Password=aQO6Uxbk6XXfxq46E9PfYBi-HWn_a6mP;";
                using var con = new NpgsqlConnection(cs);
                con.Open();

                string sql = "SELECT \"Email\" FROM public.\"AspNetUsers\"";

                using var cmd = new NpgsqlCommand(sql, con);
                using var reader = cmd.ExecuteReader();

                var result = new List<string>();

                while (reader.Read())
                {
                    result.Add(reader.GetString(0));
                }

                return result;
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}

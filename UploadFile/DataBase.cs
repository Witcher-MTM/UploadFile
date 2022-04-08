using System.Data.SqlClient;

namespace UploadFile
{
    public class DataBase
    {
        private string connectionString;
        private SqlConnection conn;
        public DataBase()
        {
            connectionString = @"Data Source = SQL5063.site4now.net; Initial Catalog = db_a838e6_gray; User Id = db_a838e6_gray_admin; Password = q1w2e3r4t5y6u7i8";
            conn = new SqlConnection(connectionString);
        }
        public void ConnectToDB()
        {
            try
            {
                conn.Open();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void InsertFile(string fileName, byte[] data)
        {
            string query = $"INSERT INTO File_Info (File_Name,Data) VALUES (@File_Name,@Data)";
            using (SqlCommand sqlCommand = new SqlCommand(query,conn))
            {
                try
                {
                    SqlParameter parameter1 = sqlCommand.Parameters.AddWithValue("@File_Name", fileName);
                    parameter1.DbType = System.Data.DbType.String;
                    SqlParameter parameter2 = sqlCommand.Parameters.AddWithValue("@Data", data);
                    parameter2.DbType = System.Data.DbType.Binary;

                    sqlCommand.ExecuteNonQuery();
                }
                catch (System.Exception)
                {

                    throw;
                }
            }

        }
    }
}

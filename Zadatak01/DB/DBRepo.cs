using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Zadatak01.Model;

namespace Zadatak01.DB
{
    public class DBConnection
    {

        private static string CS = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        private static SqlDataReader result;

        public static DataTable getAparments(string sortBy, string city)
        {
            DataTable tblUsers = new DataTable();
            string[] parametri = sortBy.Split(' ');
            
            IList<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("SortBy", parametri[0]));
            param.Add(new SqlParameter("City", city));
            List<SqlParameter> parameters = new List<SqlParameter>();
            try
            {
                tblUsers = SqlHelper.ExecuteDataset(CS, nameof(getAparments),param[0], param[1]).Tables[0];
            }
            catch(Exception ex)
            {
                return null;
            }
            if(parametri[1]=="D")
            return tblUsers.AsEnumerable().Reverse().CopyToDataTable();
            return tblUsers;
        }

        internal static DataTable getAllTagTypes()
        {
            DataTable tblAparment = new DataTable();


            try
            {
                tblAparment = SqlHelper.ExecuteDataset(CS, nameof(getAllTagTypes)).Tables[0];
            }
            catch (Exception ex)
            {

            }
            return tblAparment;
        }

        public static DataTable getAparment(string id)
        {

            DataTable tblAparment = new DataTable();
            
            
            try
            {
                tblAparment = SqlHelper.ExecuteDataset(CS, nameof(getAparment), new SqlParameter("Id", id)).Tables[0];
            }
            catch (Exception ex)
            {

            }
            return tblAparment;
        }

        public static IList<Tag> getTags(string id)
        {
          
                 IList<Tag> images = new List<Tag>();
            if (id == null) return images;
            using (var conn = new SqlConnection(CS))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                      $"select t.Name from TaggedApartment ta"+
                       $" inner join Tag t on t.Id = ta.TagId"+
                    $" where ta.ApartmentId = { id };",
                    conn);
                ;
                DataSet ds = new DataSet();
                da.Fill(ds, "TagName"); //napuni dataset
                foreach (DataTable dt in ds.Tables)
                {
                    //foreach (DataColumn dc in dt.Columns)
                    //{
                    //}
                    foreach (DataRow dr in dt.Rows)
                    {
                        images.Add(new Tag { TagName = dr["Name"].ToString() });
                    }
                }
            }
            return images;
        }

        public static IList<User> GetUsers()
        {
            IList<User> users = new List<User>();
            using (var conn = new SqlConnection(CS))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                      $"select UserName, Email, Address from AspNetUsers;",
                    conn);
                ;
                DataSet ds = new DataSet();
                da.Fill(ds, "UserName"); 
                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        users.Add(new User { UserName = dr["UserName"].ToString(), Email= dr["Email"].ToString(), 
                        Address= dr["Address"].ToString()
                        });
                    }
                }
            }
            return users;
        }

        public static IList<Tag> getAllTags()
        {
            IList<Tag> images = new List<Tag>();
            using (var conn = new SqlConnection(CS))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                      $"select Name,(select COUNT(*) from TaggedApartment ta"+
                      $" where ta.TagId = tg.Id"+
                      $") as 'Count' from tag tg",
                    conn);
                ;
                DataSet ds = new DataSet();
                da.Fill(ds, "TagName"); //napuni dataset
                foreach (DataTable dt in ds.Tables)
                {
                    //foreach (DataColumn dc in dt.Columns)
                    //{
                    //}
                    foreach (DataRow dr in dt.Rows)
                    {
                        images.Add(new Tag { TagName = dr["Name"].ToString(), Count= (int)dr["Count"] });
                    }
                }
            }
            return images;
        }

        public static void deleteApartmantTag(int id, string tag)
        {
            using (var conn = new SqlConnection(CS))
                using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = $"delete from TaggedApartment " +
                                  $"where ApartmentId = {id} and " +
                                  $"TagId = (select Id from Tag where Name = '{tag}');";
                cmd.ExecuteNonQuery();
            }
        }

        public static void deleteTag(string tag)
        {
            using (var conn = new SqlConnection(CS))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = $"delete from tag where Name = '{tag}'";
                var a = cmd.CommandText;
                var b = cmd.ExecuteNonQuery();
            }
}public static void addTag(string typeId, string tag)
        {
            using (var conn = new SqlConnection(CS))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = $"insert into Tag(TypeId, Name) values({typeId},'{tag}');";
                var a = cmd.CommandText;
                var b = cmd.ExecuteNonQuery();
            }
}

        

        public static IList<Slika> getImages(string id)
        {
            IList<Slika> images = new List<Slika>();
            if (id == null) return images;
            using (var conn = new SqlConnection(CS))
            {
                SqlDataAdapter da =  new SqlDataAdapter(
                    $"select Path from ApartmentPicture where ApartmentId = {id}",
                    conn);
               ;
                DataSet ds = new DataSet();
                da.Fill(ds, "Path"); //napuni dataset
                foreach (DataTable dt in ds.Tables)
                {
                    //foreach (DataColumn dc in dt.Columns)
                    //{
                    //}
                    foreach (DataRow dr in dt.Rows)
                    {
                        images.Add(new Slika{Path=dr["Path"].ToString()});
                      
                    }
                }
            }
                return images;
        }

        public static DataTable getCities()
        {
            DataTable tblCities = new DataTable();

            try
            {
                tblCities = SqlHelper.ExecuteDataset(CS, nameof(getCities)).Tables[0];
            }catch(Exception ex)
            {
            }
            return tblCities;
        }

       

        public static void updateAparment(string BeachDistance, string Status, string NumberOfAdults,
            string NumberOfChildren, string NumberOfRooms, string Address, string Price, int id)
        {
           
            using (var conn = new SqlConnection(CS))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText =  $"update Apartment SET " +
                                   $"BeachDistance = {BeachDistance}" +
                                   $",StatusId = 2" +
                                   $",MaxAdults = {NumberOfAdults}" +
                                   $",MaxChildren = {NumberOfChildren}" +
                                   $",TotalRooms = {NumberOfRooms}" +
                                   $",Address = '{Address}'" +
                                   $",Price = {Price}"+
                                   $" where Id = {id};";
                var a = cmd.CommandText;
                var b = cmd.ExecuteNonQuery();
            }
        }

        public static void deleteApartment(int id)
        {
            using (var conn = new SqlConnection(CS))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = $"update Apartment SET " +
                                   $"DeletedAt = current_timestamp" +
                                   $" where Id = {id};";
                var a = cmd.CommandText;
                var b = cmd.ExecuteNonQuery();
            }
        }

        public static void addApartment(string city, string address, string name, string nameEng, string Price, string maxAdults,
            string TotalRooms, string BeachDistance, string Children)
        {
            using (var conn = new SqlConnection(CS))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = $"if not exists (select * from City where Name='{city}')" +
                                  $" begin"+
                                 $" insert into City(Name) values('{city}');"+
                                  $" end";
                var b = cmd.CommandText;
                cmd.ExecuteNonQuery();
            }
            using (var conn = new SqlConnection(CS))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = $"insert into Apartment(CityId, Address, Name, NameEng, Price, MaxAdults, MaxChildren, TotalRooms, BeachDistance, OwnerId, TypeId, StatusId) " +
                                  $" values((select Id from City where Name = '{city}'),'{address}', '{name}', '{nameEng}', {Price}," +
                                  $"{maxAdults}, {Children}, {TotalRooms}, {BeachDistance}, 1, 1, 1);";
                cmd.ExecuteNonQuery();
            }
        }
        
    }
}
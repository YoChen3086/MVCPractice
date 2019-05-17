using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MVCPractice
{
    public class DBContext
    {
        // Singleton
        private static readonly Lazy<DBContext> Lazy = new Lazy<DBContext>(() => new DBContext());

        public static DBContext Current => Lazy.Value;

        private static string _connectionString = "server=127.0.0.1;port=3306;user id=root;password=!QAZ2wsx;database=mvcpractice;charset=utf8;";

        public void Insert()
        {
            List<City> cities = new List<City>();
            cities.Add(new City("0", "基隆市"));
            cities.Add(new City("1", "臺北市"));
            cities.Add(new City("2", "新北市"));
            cities.Add(new City("3", "桃園市"));
            cities.Add(new City("4", "新竹市"));
            cities.Add(new City("5", "新竹縣"));
            cities.Add(new City("6", "宜蘭縣"));
            cities.Add(new City("7", "苗栗縣"));
            cities.Add(new City("8", "臺中市"));
            cities.Add(new City("9", "彰化縣"));
            cities.Add(new City("A", "南投縣"));
            cities.Add(new City("B", "雲林縣"));
            cities.Add(new City("C", "嘉義市"));
            cities.Add(new City("D", "嘉義縣"));
            cities.Add(new City("E", "臺南市"));
            cities.Add(new City("F", "高雄市"));
            cities.Add(new City("G", "屏東縣"));
            cities.Add(new City("H", "澎湖縣"));
            cities.Add(new City("I", "花蓮縣"));
            cities.Add(new City("J", "臺東縣"));
            cities.Add(new City("K", "金門縣"));
            cities.Add(new City("L", "連江縣"));

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (var conn = connection.BeginTransaction())
                {
                    string insert = $"INSERT INTO `city`(`id`, `name`) values (@id, @name)";
                    connection.Execute(insert, cities, conn);
                    conn.Commit();
                }
                connection.Close();
            }
        }

        public IEnumerable<City> QueryCityList()
        {
            IEnumerable<City> cities = new List<City>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = $"select id, name from `city`";
                cities = connection.Query<City>(query);
                connection.Close();

                return cities;
            }
        }

        public IEnumerable<Village> QueryVillageList(string id)
        {
            IEnumerable<Village> villages = new List<Village>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = $"select id, village as name from `village` where city in (select name from city where id = '{id}')";
                villages = connection.Query<Village>(query);
                connection.Close();

                return villages;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using CrmDemo.Models;

namespace CrmDemo.Services
{
    public class DataService
    {
        private readonly string _crmDataPath = "crm_data.json";
        private readonly string _usersPath = "users.json";

        public CrmData LoadCrmData()
        {
            if (!File.Exists(_crmDataPath))
            {
                return new CrmData();
            }

            string json = File.ReadAllText(_crmDataPath);
            return JsonSerializer.Deserialize<CrmData>(json) ?? new CrmData();
        }

        public void SaveCrmData(CrmData data)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(data, options);
            File.WriteAllText(_crmDataPath, json);
        }

        public List<User> LoadUsers()
        {
            if (!File.Exists(_usersPath))
            {
                var defaultUsers = new List<User>();
                defaultUsers.Add(new User { Login = "admin", PasswordHash = GetHash("admin123"), Role = "Admin", FullName = "Администратор" });
                defaultUsers.Add(new User { Login = "manager", PasswordHash = GetHash("manager123"), Role = "Manager", FullName = "Менеджер" });
                SaveUsers(defaultUsers);
                return defaultUsers;
            }

            string json = File.ReadAllText(_usersPath);
            return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }

        public void SaveUsers(List<User> users)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(users, options);
            File.WriteAllText(_usersPath, json);
        }

        private string GetHash(string input)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        public bool VerifyPassword(string password, string hash)
        {
            return GetHash(password) == hash;
        }
    }

    public class CrmData
    {
        public List<Client> Clients { get; set; }
        public List<Deal> Deals { get; set; }
        public List<Contact> Contacts { get; set; }

        public CrmData()
        {
            Clients = new List<Client>();
            Deals = new List<Deal>();
            Contacts = new List<Contact>();
        }
    }
}
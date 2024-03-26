using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using StudentManagementSystem.entities;
using StudentManagementSystem.Model;

namespace StudentManagementSystem.DataAccess
{
    internal class UserDA
    {
		private DataContext _dbContext = new DataContext();
  
		public bool AddUser(User user)  
		{  
			const string query = "INSERT INTO tblUsers(userName, address, password, fullName, regNum, imagePath, imageData) VALUES(@userName, @address, @password, @fullName, @regNum, @imagePath, @imageData)";  
  
			var args = new Dictionary<string, object>  
			{ 
				{"@userId", user.Id},
				{"@userName", user.Name},  
				{"@address", user.Address},
				{"@password", user.Password},
				{"@fullName", user.FullName},
				{"@regNum", user.RegNum},
				{"@imagePath", user.ImagePath},
				{"@imageData", user.ImageData},
			};  
  
			_dbContext.ExecuteWrite(query, args);
			return true;
		}

        public User UpdateUser(User user)
        {
            const string query = "UPDATE tblUsers SET address = @address, fullName = @fullName, RegNum = @regNum WHERE userId = @userId";

            var args = new Dictionary<string, object>
    {
        {"@userId", user.Id},
        {"@fullName", user.FullName},
        {"@address", user.Address},
        {"@regNum", user.RegNum}
    };

            _dbContext.ExecuteWrite(query, args);
            return new User();
        }




        public void RemoveUser(int id)  
		{  
			const string query = "Delete from tblUsers WHERE userId = @userId";  
  
			var args = new Dictionary<string, object>  
			{  
				{"@userId", id}  
			};  
  
			_dbContext.ExecuteWrite(query, args);  
			
		}  
  
		public User Get(string userName)  
		{  
			var user = new User();  
  
			var query = "SELECT * FROM tblUsers WHERE userName = @userName";  
  
			var args = new Dictionary<string, object>  
			{  
				{"@userName", userName}  
			};  
  
			DataTable dt = _dbContext.Execute(query, args);  
  
			if (dt == null || dt.Rows.Count == 0)  
			{  
				return null;  
			}  
  
			user = new User  
			{  
				Id = Convert.ToInt32(dt.Rows[0]["userId"]), 
				Name = (string)(dt.Rows[0]["userName"]),  
				Address = (string)dt.Rows[0]["address"],
				Password = (string)dt.Rows[0]["password"],
				FullName = (string)dt.Rows[0]["fullName"],
				RegNum = (string)dt.Rows[0]["regNum"],
				ImagePath = (string)dt.Rows[0]["imagePath"],
				ImageData = (byte[])dt.Rows[0]["imageData"]
			};  
  
			return user;  
		}  
  
        public List<User> GetAll()  
        {  
			var user = new User();  
  
			var query = "SELECT * FROM tblUsers";  
  
			var args = new Dictionary<string, object>  
			{  
				{"@userName", user.Id}  
			};  
  
			DataTable dt = _dbContext.Execute(query, args);  
  
			if (dt == null || dt.Rows.Count == 0)  
			{  
				return null;  
			}  
			
			var users = new List<User>();  
			foreach (DataRow row in dt.Rows)  
			{  
				var obj = new User()  
				{ 
					Id = Convert.ToInt32(row["userId"]), 
					Name = (string)(row["userName"]),  
					Address = (string)row["address"],
					Password = (string)row["password"],
					FullName = (string)row["fullName"],
					RegNum = (string)row["regNum"],
					ImagePath = (string)row["imagePath"],
					ImageData = (byte[])row["imageData"]
				};  
				users.Add(obj);
			}
			
			return users;  
			
			
  

        }  
        
    }
}
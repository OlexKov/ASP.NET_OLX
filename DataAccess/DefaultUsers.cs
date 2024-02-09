using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
	internal static class DefaultUsers
	{
		public static void Initialize(ModelBuilder modelBuilder)
		{
			string ADMIN_ROLE_ID = "15b04d9eff654d8d966a172db59e2722";
			string USER_ROLE_ID = "59139483f3d1417db1efee50d14b6a7f";

			string ADMIN_ID = "f66e492517d7414495e988c4c50fd107";
			string USER2_ID = "d1901b2435594da2a255db13fc57509b";
			string USER3_ID = "c86dc56aedf549f6afe5ceb4d414ebf1";
			string USER4_ID = "028582c83a914a45b330b5234f4131fb";
			string USER5_ID = "eb05f9548a2c4cf8adcc2be7305fc732";
           

			modelBuilder.Entity<IdentityRole>().HasData(
				new IdentityRole
			    {
					Name = "Admin",
					NormalizedName = "ADMIN",
					Id = ADMIN_ROLE_ID,
					ConcurrencyStamp = ADMIN_ROLE_ID,

			    },
				new IdentityRole
				{
					Name = "User",
					NormalizedName = "USER",
					Id = USER_ROLE_ID,
					ConcurrencyStamp = USER_ROLE_ID,
				}
			);

			CreateUser(new DateTime(1998,1,12),ADMIN_ID, "Admin@gmail.com",true,"Петро","Левак", ADMIN_ROLE_ID,"Admin_1",modelBuilder);
			CreateUser(new DateTime(1988, 10, 14), USER2_ID, "User1@gmail.com", true, "Iван", "Калита", USER_ROLE_ID, "User_1", modelBuilder);
			CreateUser(new DateTime(2000, 11, 5), USER3_ID, "User2@gmail.com", true, "Петро", "Дякуленко", USER_ROLE_ID, "User_2", modelBuilder);
			CreateUser(new DateTime(1999, 7, 7), USER4_ID, "User3@gmail.com", true, "Олег", "Панасенко", USER_ROLE_ID, "User_3", modelBuilder);
			CreateUser(new DateTime(2001, 6, 9), USER5_ID, "User4@gmail.com", true, "Тимофій", "Гнатенко", USER_ROLE_ID, "User_4", modelBuilder);
		}

		private static void CreateUser(DateTime birthdate,string userId,string email,bool emailConfirmed,string name,string surname,string roleId,string password, ModelBuilder modelBuilder)
		{
			var appUser = new User
			{
				Id = userId,
				Email = email,
				EmailConfirmed = emailConfirmed,
				Name = name,
				Surname = surname,
				UserName = email,
				NormalizedUserName = email.ToUpper(),
				Birthdate = birthdate
			};
			PasswordHasher<User> ph = new();
			appUser.PasswordHash = ph.HashPassword(appUser, password);
			modelBuilder.Entity<User>().HasData(appUser);
			modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
			{
				RoleId = roleId,
				UserId = userId
			});
		}
	}
}

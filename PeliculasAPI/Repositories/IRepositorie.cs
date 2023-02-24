using System;
using PeliculasAPI.Entities;

namespace PeliculasAPI.Repositories
{
	public interface IRepositorie
	{
        void CreateGender(Gender gender);
        Guid getGuid();
        Task<Gender> GetGenderById(int Id);
        List<Gender> GetAllGenders();


    }
}


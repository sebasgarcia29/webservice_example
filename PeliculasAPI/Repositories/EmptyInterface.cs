using System;
using PeliculasAPI.Entities;

namespace PeliculasAPI.Repositories
{
	public interface IRepositorie
	{
        Task<Gender> GetGenderById(int Id);
        List<Gender> GetAllGenders();


    }
}


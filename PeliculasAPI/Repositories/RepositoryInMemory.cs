using System;
using PeliculasAPI.Entities;

namespace PeliculasAPI.Repositories
{
    public class RepositoryInMemory: IRepositorie
    {

        private List<Gender> _genders;

        public RepositoryInMemory()

        {
            _genders = new List<Gender>() {
            new Gender() { Id = 1, Name= "Test1"},
            new Gender() { Id = 2, Name = "Test2" }
        	};

            _guid = Guid.NewGuid();

        }


        public Guid _guid;

            
        public List<Gender> GetAllGenders()
        {
    		return _genders;
        }

        public async Task<Gender> GetGenderById(int Id)
        {
            await Task.Delay(TimeSpan.FromSeconds(3));
            return _genders.FirstOrDefault(x => x.Id == Id);
        }


        public Guid getGuid()
        {
            return _guid;
        }

        public void CreateGender(Gender gender)
        {
            gender.Id = _genders.Count() + 1;
            _genders.Add(gender);

        }

    }
}


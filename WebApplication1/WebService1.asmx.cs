using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication1
{

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WebService1 : System.Web.Services.WebService
    {
        public Collection<Person> People { get; set; } = new Collection<Person>();
        [WebMethod]
        public string GetAllPeopleText()
        {
            var temp = "";
            foreach (var item in People)
            {
                temp += $"{item.ToString()}\n";
            }
            return temp ;
        }
        [WebMethod]
        public IEnumerable<Person> GetAllPeople() => People;
        [WebMethod]
        public bool Create(Person personToAdd)
        {
            if (People.Any(x => x.ID == personToAdd.ID)) return false;
            People.Add(personToAdd);
            return true;
            
        }
        [WebMethod]
        public bool Delete(int id)
        {
           return People.Remove(People.FirstOrDefault(x => x.ID == id));
        }
        [WebMethod]
        public Person GetPersonByID(int id)
        {
            return People.FirstOrDefault(x => x.ID == id);
        }
        [WebMethod]
        public IEnumerable<Person> GetPersonByLastName(string lastName)
        {

            return People.Where(x => x.LastName == lastName);
        }
        [WebMethod] 
        public void Update(Person updatedPerson)
        {
            People.FirstOrDefault(x => x.ID == updatedPerson.ID).FirstName = updatedPerson.FirstName;

            People.FirstOrDefault(x => x.ID == updatedPerson.ID).LastName = updatedPerson.LastName;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebPihare.Entities
{
    public partial class Commisioner
    {
        public Commisioner()
        {
            Client = new HashSet<Client>();
            Visitregistration = new HashSet<Visitregistration>();
        }

        public int CommisionerId { get; set; }
        [DisplayName("Nombre")]
        public string FirstName { get; set; }
        [DisplayName("Primer Apellido")]
        public string LastName { get; set; }
        [DisplayName("Segundo Apellido")]
        public string SecondLastName { get; set; }
        [DisplayName("Nickname")]
        public string Nic { get; set; }
        [DisplayName("Numero de contrato")]
        public int ContractNumber { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,50}$",
                                ErrorMessage = "La password debe ser almenos de 8 caracteres y contener de 3 a 4 de los siguientes: Mayusculas, minusculas, numeros y caracteres especiales (e.g. !@#$%^&*)")]

        public string CommisionerPassword { get; set; }
        public int RoleId { get; set; }
        [DisplayName("Role")]
        public Role Role { get; set; }

        [DisplayName("Nombre Comisionista")]
        public string FullName{ get {

                string FullNameCommisioner = $"{FirstName} {LastName} {SecondLastName}";
                return FullNameCommisioner;
            } }
        public ICollection<Client> Client { get; set; }
        public ICollection<Visitregistration> Visitregistration { get; set; }
    }
}
